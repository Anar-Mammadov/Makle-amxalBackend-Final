using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Application.TestimionalsS
{
    
    public class TestimionalsSingleQuery : IRequest<Testimionals>
    {
        // bu hisse query model adlanir;(axtaris zamani bura lazim olur)
        public int Id { get; set; }


        // nested class clasin icinde class
        public class TestimionalsSingleQueryHandler : IRequestHandler<TestimionalsSingleQuery, Testimionals>
        {
            readonly MaklerSamxalDbContext db;
            public TestimionalsSingleQueryHandler(MaklerSamxalDbContext db)
            {
                this.db = db; //Model
            }
            // qeury servic adlanir;    
            public async Task<Testimionals> Handle(TestimionalsSingleQuery model, CancellationToken cancellationToken)
            {

                if (model.Id <= 0)
                {
                    return null;
                }
                var blog = await db.Testimionalss
                    .FirstOrDefaultAsync(m => m.Id == model.Id, cancellationToken);

                return blog;
            }
        }

    }
}
