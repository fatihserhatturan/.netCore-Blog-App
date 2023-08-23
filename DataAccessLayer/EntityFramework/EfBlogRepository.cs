using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : Repository<Blog>, IBlogDal
    {

        public List<Blog> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Blogs
                    .Include(x => x.Category)
                    .Include(x => x.Author)
                    .ToList();
            }
        }


    }
}
