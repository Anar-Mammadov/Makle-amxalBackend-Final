using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Application.Ageds
{
    public class AgentsViewModel
    {
        public int? Id { get; set; }
        public string ImagePath { get; set; }
        public string Position { get; set; }
        public string FullName { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public IFormFile file { get; set; }
    }
}
