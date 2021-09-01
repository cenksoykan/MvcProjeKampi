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

        public GalleryImage GetById(int id)
        {
            return _galleryImageDal.Get(x => x.GalleryImageId == id);
        }

        public void Update(GalleryImage galleryImage)
        {
            _galleryImageDal.Update(galleryImage);
        }
    }
}
