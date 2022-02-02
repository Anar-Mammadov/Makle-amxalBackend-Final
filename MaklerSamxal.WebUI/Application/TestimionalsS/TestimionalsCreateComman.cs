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

namespace MaklerSamxal.WebUI.Application.TestimionalsS
{
   

    public class TestimionalsCreateComman : IRequest<Testimionals>
    {

        public string ImagePath { get; set; }
        public string FullName { get; set; }
        public string Customer { get; set; }
        public string Desription { get; set; }

        public IFormFile file { get; set; }

        public class TestimionalsCreateCommanHandler : IRequestHandler<TestimionalsCreateComman, Testimionals>
        {
            readonly MaklerSamxalDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IHostEnvironment env;
            public TestimionalsCreateCommanHandler(MaklerSamxalDbContext db, IActionContextAccessor ctx, IHostEnvironment env) //Model.State burda yoxlamaq ucun yazilib.
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<Testimionals> Handle(TestimionalsCreateComman model, CancellationToken cancellationToken)
            {


                if (ctx.ModelStateValid())
                {
                    Testimionals blog = new Testimionals();
                    string extension = Path.GetExtension(model.file.FileName);  //.jpg tapmaq ucundur. png .gng 

                    blog.ImagePath = $"{Guid.NewGuid()}{extension}";//imagenin name 


                    string phsicalFileName = Path.Combine(env.ContentRootPath, "wwwroot", "assets", "images", blog.ImagePath);

                    using (var stream = new FileStream(phsicalFileName, FileMode.Create, FileAccess.Write))
                    {
                        await model.file.CopyToAsync(stream);
                    }

                    blog.CreateData = DateTime.Now;
                    blog.FullName = model.FullName;
                    blog.Customer = model.Customer;
                    blog.Desription = model.Desription;



                    db.Add(blog);
                    await db.SaveChangesAsync(cancellationToken);

                    return blog;

                }
                return null;
            }
        }
    }
}
