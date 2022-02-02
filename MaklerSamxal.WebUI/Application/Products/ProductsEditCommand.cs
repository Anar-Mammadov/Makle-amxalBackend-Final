using MaklerSamxal.WebUI.Application.Core;
using MaklerSamxal.WebUI.Models.DataContexts;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Application.Products
{
    
    public class ProductsEditCommand : ProductsViewModel, IRequest<int>
    {


        public class ProductsEditCommandHandler : IRequestHandler<ProductsEditCommand, int>
        {
            readonly MaklerSamxalDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IHostEnvironment env;


            public ProductsEditCommandHandler(MaklerSamxalDbContext db, IActionContextAccessor ctx, IHostEnvironment env)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(ProductsEditCommand request, CancellationToken cancellationToken)
            {

                if (request.Id != request.Id)
                {
                    return 0;
                }


                if (string.IsNullOrWhiteSpace(request.ImagePath) && request.file == null)
                {

                    ctx.ActionContext.ModelState.AddModelError("file", "Not Chosen");
                }

                var entity = await db.Products.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeleteByUserId == null);

                if (entity == null)
                {
                    return 0;
                }

                if (ctx.ModelStateValid())
                {
                    entity.Title = request.Title;
                    entity.Location = request.Location;
                    entity.ImagePath = request.ImagePath;
                    entity.Price = request.Price;
                    entity.Bed = request.Bed;
                    entity.Baths = request.Baths;
                    entity.Sqft = request.Sqft;
                    entity.Description = request.Description;
                    entity.ShopDescription = request.ShopDescription;
                    // entity.CreateData = request.CreatedData;





                    if (request.file != null)
                    {

                        string extension = Path.GetExtension(request.file.FileName);  //.jpg tapmaq ucundur.

                        request.ImagePath = $"{Guid.NewGuid()}{extension}";//imagenin name 


                        string phsicalFileName = Path.Combine(env.ContentRootPath, "wwwroot", "assets", "images", request.ImagePath);

                        using (var stream = new FileStream(phsicalFileName, FileMode.Create, FileAccess.Write))
                        {
                            await request.file.CopyToAsync(stream);
                        }

                        if (!string.IsNullOrWhiteSpace(entity.ImagePath))
                        {
                            System.IO.File.Delete(Path.Combine(env.ContentRootPath, "wwwroot", "assets", "images", entity.ImagePath));

                        }
                        entity.ImagePath = request.ImagePath;
                    }

                    await db.SaveChangesAsync(cancellationToken);
                    return entity.Id;



                }
                return 0;

            }

        }

    }
}
