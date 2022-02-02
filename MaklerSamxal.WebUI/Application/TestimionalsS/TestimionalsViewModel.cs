using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Application.TestimionalsS
{
    public class TestimionalsViewModel
    {
        public int? Id { get; set; }
        public string ImagePath { get; set; }
        public string FullName { get; set; }
        public string Customer { get; set; }
        public string Desription { get; set; }
        public IFormFile file { get; set; }
    }
}
