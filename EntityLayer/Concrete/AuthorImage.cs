using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class AuthorImage
    {
        public IFormFile Image { get; set; }
        public int AuthorID { get; set; }
        [StringLength(50)]
        public string AuthorName { get; set; }

        [StringLength(250)]
        public string AuthorAbout { get; set; }
        [StringLength(50)]
        public string AuthorTitle { get; set; }
        [StringLength(100)]
        public string AuthorAboutShort { get; set; }
        [StringLength(50)]
        public string AuthorMail { get; set; }
        [StringLength(50)]
        public string AuthorPassword { get; set; }
        [StringLength(20)]
        public string AuthorPhoneNumber { get; set; }
    }
}
