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

namespace MaklerSamxal.WebUI.Application.Ageds
{
  

    public class AgentsEditCommand : AgentsViewModel, IRequest<int>
    {


        public class AgentsEditCommandHandler : IRequestHandler<AgentsEditCommand, int>
        {
            readonly MaklerSamxalDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IHostEnvironment env;


            public AgentsEditCommandHandler(MaklerSamxalDbContext db, IActionContextAccessor ctx, IHostEnvironment env)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(AgentsEditCommand request, CancellationToken cancellationToken)
            {

                if (request.Id != request.Id)
                {
                    return 0;
                }


                if (string.IsNullOrWhiteSpace(request.ImagePath) && request.file == null)
                {

                    ctx.ActionContext.ModelState.AddModelError("file", "Not Chosen");
                }

                var entity = await db.Agents.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeleteByUserId == null);

                if (entity == null)
                {
                    return 0;
                }

                if (ctx.ModelStateValid())
                {
                    entity.Position = request.Position;
                    entity.FullName = request.FullName;
                    entity.ImagePath = request.ImagePath;
                    entity.Instagram = request.Instagram;
                    entity.Facebook = request.Facebook;
                    entity.Twitter = request.Twitter;
                    entity.Linkedin = request.Linkedin;
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
