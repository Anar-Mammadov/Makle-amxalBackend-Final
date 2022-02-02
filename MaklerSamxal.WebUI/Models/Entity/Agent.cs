using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Models.Entity
{
    public class Agent : BaseEntity
    {
        public string ImagePath { get; set; }
        public string Position { get; set; }
        public string FullName { get; set; }
        public string Instagram{ get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }

    }
}
