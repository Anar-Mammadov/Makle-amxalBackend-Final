using System.Collections.Generic;

namespace MaklerSamxal.WebUI.Models.Entity
{
    public class Blog :BaseEntity
    {

        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public  string Body { get; set; }
        public string CreatedData { get; set; }
        public virtual ICollection<BlogPostComment> Comments { get; set; }


    }
}
