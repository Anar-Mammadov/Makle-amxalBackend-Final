using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Models.Entity.Membership
{
    public class MaklerUser:IdentityUser<int>
    {
        public bool Activates { get; set; }

    }
}
