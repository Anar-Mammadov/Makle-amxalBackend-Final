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

namespace MaklerSamxal.WebUI.Application.Ageds
{
  

    public class AgentsCreateComman : IRequest<Agent>
    {

        public string ImagePath { get; set; }
        public string Position { get; set; }
        public string FullName { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }

        public IFormFile file { get; set; }

        public class AgentsCreateCommanHandler : IRequestHandler<AgentsCreateComman, Agent>
        {
            readonly MaklerSamxalDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IHostEnvironment env;
            public AgentsCreateCommanHandler(MaklerSamxalDbContext db, IActionContextAccessor ctx, IHostEnvironment env) //Model.State burda yoxlamaq ucun yazilib.
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<Agent> Handle(AgentsCreateComman model, CancellationToken cancellationToken)
            {


                if (ctx.ModelStateValid())
                {
                    Agent blog = new Agent();
                    string extension = Path.GetExtension(model.file.FileName);  //.jpg tapmaq ucundur. png .gng 

                    blog.ImagePath = $"{Guid.NewGuid()}{extension}";//imagenin name 


                    string phsicalFileName = Path.Combine(env.ContentRootPath, "wwwroot", "assets", "images", blog.ImagePath);

                    using (var stream = new FileStream(phsicalFileName, FileMode.Create, FileAccess.Write))
                    {
                        await model.file.CopyToAsync(stream);
                    }

                    blog.CreateData = DateTime.Now;
                    blog.Position = model.Position;
                    blog.FullName = model.FullName;
                    blog.Instagram = model.Instagram;
                    blog.Facebook = model.Facebook;
                    blog.Twitter = model.Twitter;
                    blog.Linkedin = model.Linkedin;



                    db.Add(blog);
                    await db.SaveChangesAsync(cancellationToken);

                    return blog;

                }
                return null;
            }
        }
    }
}
