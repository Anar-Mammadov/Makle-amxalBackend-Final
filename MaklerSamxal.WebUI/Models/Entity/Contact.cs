using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Models.Entity
{
    public class Contact :BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }


        public string Answer { get; set; }

        public DateTime? AnswerData { get; set; }

        public int? AnswerByUserId { get; set; }




    }
}
