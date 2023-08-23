using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public  class BlogImage
    {
        public int BlogID { get; set; }
        [StringLength(100)]
        public string BlogTitle { get; set; }
       
        //public string BlogImage { get; set; }
        //public string BlogImage2 { get; set; }
        //public string BlogImage3 { get; set; }
        //public string BlogImage4 { get; set; }
        //public string BlogImage5 { get; set; }
        public DateTime BlogDate { get; set; }
        public string BlogContent { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public bool BlogStatus { get; set; }
        public int BlogRating { get; set; }
        public IFormFile Image1 { get; set; }
        public IFormFile Image2 { get; set; }
        public IFormFile Image3 { get; set; }
        public IFormFile Image4 { get; set; }
        public IFormFile Image5 { get; set; }
       // public ICollection<BlogImage> BlogImages { get; set; }

    }
}
