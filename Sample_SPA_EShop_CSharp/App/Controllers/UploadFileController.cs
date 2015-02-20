using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using App.ViewModels;
using Core;
using Domain.Data;
using Domain.Service;
using Microsoft.Practices.ObjectBuilder2;

namespace App.Controllers
{
    [RoutePrefix("api/image")]
    public class ImageController : ApiController
    {
        [Route("upload")]
        [HttpPost]
        public Task<HttpResponseMessage> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
                Request.CreateResponse(HttpStatusCode.HttpVersionNotSupported);

            var provider = new MultipartFormDataStreamProvider(_root);

            var task = Request.Content.ReadAsMultipartAsync(provider).ContinueWith(o =>
            {
                var filekeys = SaveImage(provider.FileData);

                return Request.CreateResponse(filekeys.Select(ImageView.Map));
            });
        
            return task; 
        }

        private readonly string _root = HttpContext.Current.Server.MapPath("~/Uploads");
        private IEnumerable<Guid> SaveImage(IEnumerable<MultipartFileData> fileData)
        {
            var fileKeys = new List<Guid>();

            fileData.ForEach(file =>
            {
                var key = Guid.NewGuid();
                var extension = Path.GetExtension(file.Headers.ContentDisposition.FileName.Replace("\"", string.Empty));
                var fileName = Path.Combine(_root, key + extension);
                var relativeFileName = key + extension;
                var localFileInfo = new FileInfo(file.LocalFileName);

                var overrideOk = false;

                while (!overrideOk)
                {
                    try
                    {
                        File.Copy(file.LocalFileName, fileName, true);
                        overrideOk = true;
                    }
                    catch (Exception)
                    {
                        File.Delete(fileName);
                    }
                }

                try
                {
                    localFileInfo.Delete();
                }
                catch (Exception)
                {

                }

                var img = Image.FromFile(fileName);
                var bmp = new Bitmap(img);

                var small = bmp.GetThumbnailImage(100, 100,
                    new Image.GetThumbnailImageAbort(ThumbnailCallback),
                    IntPtr.Zero);

                var thumbfilename = Path.Combine(_root,
                    Path.GetFileNameWithoutExtension(fileName) + "_Small" +
                    Path.GetExtension(fileName));

                small.Save(thumbfilename, ImageFormat.Jpeg);
                DependencyManager.Resolve<ImageService>().Create(
                    new Domain.Model.Image
                    {
                        Id = key,
                        Url = relativeFileName
                    });
                fileKeys.Add(key);
            });

            DependencyManager.Resolve<IUnitOfWork>().Commit();
            return fileKeys;
        }

        private bool ThumbnailCallback()
        {
            return false;
        }

    }
}