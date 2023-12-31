﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void BlogAdd(Blog blog);


        void BlogUpdate(Blog blog);

        void BlogDelete(Blog blog);

        List<Blog> GetList();

        Blog GetById(int id);

        List<Blog> GetBlogListWithCategory();

    }
}
