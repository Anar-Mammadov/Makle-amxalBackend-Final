using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Models.Entity
{
    public class BlogPostComment:BaseEntity
    {
        public string Comment { get; set; }
        public int BlogPostId { get; set; }
        public Blog BlogPost { get; set; }
        public int? ParentId { get; set; }
        public virtual BlogPostComment Parent { get; set; }
        public virtual ICollection<BlogPostComment> Children { get; set; }
    }
}
