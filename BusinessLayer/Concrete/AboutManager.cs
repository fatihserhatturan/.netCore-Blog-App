using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AboutManager
    {
        Repository<About> repoAbout= new Repository<About> ();
        public List<About> GetAll()
        {
            return repoAbout.List();
        }
    }
}
