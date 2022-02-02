using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using MaklerSamxal.WebUI.Models.ViewModel;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Application.TestimionalsS
{


    public class TestimionalsPagedQuery : IRequest<PagedViewModel<Testimionals>>
    {

        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 4;

        public class BlogPagedQueryHandler : IRequestHandler<TestimionalsPagedQuery, PagedViewModel<Testimionals>>
        {
            readonly MaklerSamxalDbContext db;
            public BlogPagedQueryHandler(MaklerSamxalDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<PagedViewModel<Testimionals>> Handle(TestimionalsPagedQuery model, CancellationToken cancellationToken)
            {
                var query = db.Testimionalss.Where(b => b.CreateByUserId == null && b.DeleteByUserId == null).AsQueryable(); // silinmemisleri getirir



                return new PagedViewModel<Testimionals>(query, model.pageIndex, model.pageSize);
            }
        }
    }
}
