using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //GenericRepository<Category> repo = new GenericRepository<Category>();
        //public List<Category> List()
        //{
        //    return repo.List();
        //}
        //public void Insert(Category p)
        //{
        //    if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryName.Length > 50 || p.CategoryDescription == "")
        //    {
        //        // error message
        //    }
        //    else
        //    {
        //        repo.Insert(p);
        //    }
        //}
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> List()
        {
            return _categoryDal.List();
        }
        public void Insert(Category category)
        {
            _categoryDal.Insert(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
