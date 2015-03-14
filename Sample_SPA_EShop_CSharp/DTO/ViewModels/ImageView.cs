using System;

namespace DTO.ViewModels
{
    public class ImageView
    {
        public Guid Key { get; set; }
        public string BigUrl { get; set; }
        public string SmallUrl { get; set; }

        public static ImageView Map(Guid key)
        {
            if (key == Guid.Empty)
                return new ImageView
                {
                    BigUrl = "app/content/images/noPic.jpg",
                    SmallUrl = "app/content/images/noPic.jpg"
                };
            //var image = DependencyManager.Resolve<IUnitOfWork>()
            //    .GetRepository<Image>().FindById(key);

            //var extension = Path.GetExtension(image.Url);
            //var big = Path.Combine("/Uploads", image.Id.ToString() + extension);
            //var small = Path.Combine("/Uploads", string.Format("{0}_Small{1}", image.Id.ToString(), extension));
            
            //return new ImageView
            //{
            //    Key = key,
            //    BigUrl = big,
            //    SmallUrl = small
            //};

            return null;
        }

        //private static readonly string _root = HttpContext.Current.Server.MapPath("~/Uploads");
    }
}