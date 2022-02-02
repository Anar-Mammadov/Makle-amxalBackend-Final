using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Application.BlogsModuls
{
    public class BlogsViewModel
    {
        public int? Id { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public string CreatedData { get; set; }
        public IFormFile file { get; set; }
    }
}
