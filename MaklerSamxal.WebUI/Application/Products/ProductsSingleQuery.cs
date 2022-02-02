using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Application.Products
{
   

    public class ProductsSingleQuery : IRequest<Product>
    {
        // bu hisse query model adlanir;(axtaris zamani bura lazim olur)
        public int Id { get; set; }


        // nested class clasin icinde class
        public class ProductsSingleQueryHandler : IRequestHandler<ProductsSingleQuery, Product>
        {
            readonly MaklerSamxalDbContext db;
            public ProductsSingleQueryHandler(MaklerSamxalDbContext db)
            {
                this.db = db; //Model
            }
            // qeury servic adlanir;    
            public async Task<Product> Handle(ProductsSingleQuery model, CancellationToken cancellationToken)
            {

                if (model.Id <= 0)
                {
                    return null;
                }
                var blog = await db.Products
                    .FirstOrDefaultAsync(m => m.Id == model.Id, cancellationToken);

                return blog;
            }
        }

    }
}
