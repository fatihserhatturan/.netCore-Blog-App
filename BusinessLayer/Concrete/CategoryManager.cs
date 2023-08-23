using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        Repository<Category> repoCategory=new Repository<Category>();
        public List<Category> GetAll()
        {
            return repoCategory.List();
        }
    }
}
