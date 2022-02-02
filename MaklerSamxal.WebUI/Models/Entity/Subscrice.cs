using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Models.Entity
{
    public class Subscrice:BaseEntity
    {
        [EmailAddress]
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public DateTime? EmailConfirmedDate { get; set; }
    }
}
