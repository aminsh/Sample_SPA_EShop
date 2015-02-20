using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.Service.Utility;

namespace Domain.Service
{
    public class ImageService
    {
        public void Create(Image image)
        {
            Repository<Image>.Instance.Add(image);
        }
    }
}
