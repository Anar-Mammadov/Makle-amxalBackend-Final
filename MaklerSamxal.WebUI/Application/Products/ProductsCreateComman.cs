using MaklerSamxal.WebUI.Application.Core;
using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Application.Products
{
    

    public class ProductsCreateComman : IRequest<Product>
    {

        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Bed { get; set; }
        public string Baths { get; set; }
        public string Sqft { get; set; }
        public string Description { get; set; }
        public string ShopDescription { get; set; }

        public IFormFile file { get; set; }

        public class ProductsCreateCommanHandler : IRequestHandler<ProductsCreateComman, Product>
        {
            readonly MaklerSamxalDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IHostEnvironment env;
            public ProductsCreateCommanHandler(MaklerSamxalDbContext db, IActionContextAccessor ctx, IHostEnvironment env) //Model.State burda yoxlamaq ucun yazilib.
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<Product> Handle(ProductsCreateComman model, CancellationToken cancellationToken)
            {


                if (ctx.ModelStateValid())
                {
                    Product blog = new Product();
                    string extension = Path.GetExtension(model.file.FileName);  //.jpg tapmaq ucundur. png .gng 

                    blog.ImagePath = $"{Guid.NewGuid()}{extension}";//imagenin name 


                    string phsicalFileName = Path.Combine(env.ContentRootPath, "wwwroot", "assets", "images", blog.ImagePath);

                    using (var stream = new FileStream(phsicalFileName, FileMode.Create, FileAccess.Write))
                    {
                        await model.file.CopyToAsync(stream);
                    }

                    blog.CreateData = DateTime.Now;
                    blog.Title = model.Title;
                    blog.Location = model.Location;
                    blog.Price = model.Price;
                    blog.Bed = model.Bed;
                    blog.Baths = model.Baths;
                    blog.Sqft = model.Sqft;
                    blog.Description = model.Description;
                    blog.ShopDescription = model.ShopDescription;



                    db.Add(blog);
                    await db.SaveChangesAsync(cancellationToken);

                    return blog;

                }
                return null;
            }
        }
    }
}
