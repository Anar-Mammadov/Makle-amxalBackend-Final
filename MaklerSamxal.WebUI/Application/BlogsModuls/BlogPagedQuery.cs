using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using MaklerSamxal.WebUI.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Application.BlogsModuls
{
    public class BlogPagedQuery : IRequest<PagedViewModel<Blog>>
    {

        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 4;

        public class BlogPagedQueryHandler : IRequestHandler<BlogPagedQuery, PagedViewModel<Blog>>
        {
            readonly MaklerSamxalDbContext db;
            public BlogPagedQueryHandler(MaklerSamxalDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<PagedViewModel<Blog>> Handle(BlogPagedQuery model, CancellationToken cancellationToken)
            {
                var query = db.Blogs.Where(b => b.CreateByUserId == null && b.DeleteByUserId == null).AsQueryable(); // silinmemisleri getirir

             

                return new PagedViewModel<Blog>(query, model.pageIndex, model.pageSize);
            }
        }
    }
}
