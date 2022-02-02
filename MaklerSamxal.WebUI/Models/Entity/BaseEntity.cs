using MaklerSamxal.WebUI.Models.Entity.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Models.Entity
{
    public class BaseEntity
    {

        public int Id { get; set; }
        public DateTime CreateData { get; set; } = DateTime.Now;
        public virtual MaklerUser DeleteByUser { get; set; }
        public int? DeleteByUserId { get; set; }
        public virtual MaklerUser CreateByUser { get; set; }
        public int? CreateByUserId { get; set; }
        public DateTime? DeleteData { get; set; }

    }
}
