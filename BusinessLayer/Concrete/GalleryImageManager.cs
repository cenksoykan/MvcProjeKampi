using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GalleryImageManager : IGalleryImageService
    {
        IGalleryImageDal _galleryImageDal;

        public GalleryImageManager(IGalleryImageDal galleryImageDal)
        {
            _galleryImageDal = galleryImageDal;
        }

        public List<GalleryImage> List()
        {
            return _galleryImageDal.List();
        }

        public void Insert(GalleryImage galleryImage)
        {
            _galleryImageDal.Insert(galleryImage);
        }

        public GalleryImage GetById(int id = 0)
        {
            return _galleryImageDal.Get(x => x.GalleryImageId == id);
        }

        public void Update(GalleryImage galleryImage)
        {
            //GalleryImage storedGalleryImage = GetById(galleryImage.GalleryImageId);
            //List<string> galleryImagePath = new List<string>
            //{
            //    storedGalleryImage.GalleryImagePath,
            //    storedGalleryImage.GalleryImageThumbPath
            //};
            //_galleryImageDal.Unchanged(storedGalleryImage);
            //string path = HttpContext.Current.Server.MapPath("~");
            //foreach (var item in galleryImagePath)
            //{
            //    if (File.Exists(path + item)) File.Move(path + item, path + "/.bak" + item);
            //}
            _galleryImageDal.Update(galleryImage);
        }
    }
}
