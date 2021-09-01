using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGalleryImageService
    {
        List<GalleryImage> List();
        void Insert(GalleryImage galleryImage);
        GalleryImage GetById(int id);
        void Update(GalleryImage galleryImage);
    }
}
