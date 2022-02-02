using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using MaklerSamxal.WebUI.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Application.Ageds
{
   

    public class AgentsPagedQuery : IRequest<PagedViewModel<Agent>>
    {

        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 4;

        public class AgentsPagedQueryHandler : IRequestHandler<AgentsPagedQuery, PagedViewModel<Agent>>
        {
            readonly MaklerSamxalDbContext db;
            public AgentsPagedQueryHandler(MaklerSamxalDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<PagedViewModel<Agent>> Handle(AgentsPagedQuery model, CancellationToken cancellationToken)
            {
                var query = db.Agents.Where(b => b.CreateByUserId == null && b.DeleteByUserId == null).AsQueryable(); // silinmemisleri getirir

                return new PagedViewModel<Agent>(query, model.pageIndex, model.pageSize);
            }
        }
    }
}
