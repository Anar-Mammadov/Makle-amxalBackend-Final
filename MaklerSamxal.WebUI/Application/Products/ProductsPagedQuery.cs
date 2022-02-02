using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using MaklerSamxal.WebUI.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Application.Products
{
    

    public class ProductsPagedQuery : IRequest<PagedViewModel<Product>>
    {

        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 4;

        public class ProductsPagedQueryHandler : IRequestHandler<ProductsPagedQuery, PagedViewModel<Product>>
        {
            readonly MaklerSamxalDbContext db;
            public ProductsPagedQueryHandler(MaklerSamxalDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<PagedViewModel<Product>> Handle(ProductsPagedQuery model, CancellationToken cancellationToken)
            {
                var query = db.Products.Where(b => b.CreateByUserId == null && b.DeleteByUserId == null).AsQueryable(); // silinmemisleri getirir

                return new PagedViewModel<Product>(query, model.pageIndex, model.pageSize);
            }
        }
    }
}
