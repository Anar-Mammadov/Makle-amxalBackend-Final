using MaklerSamxal.WebUI.Application.Core.Infrastructure;
using MaklerSamxal.WebUI.Models.DataContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Application.TestimionalsS
{
   

    public class TestimionalsRemoveCommand : IRequest<CommandJsonRespons>
    {

        public int? Id { get; set; }


        public class TestimionalsRemoveCommandHandler : IRequestHandler<TestimionalsRemoveCommand, CommandJsonRespons>
        {
            readonly MaklerSamxalDbContext db;
            public TestimionalsRemoveCommandHandler(MaklerSamxalDbContext db)
            {
                this.db = db;
            }
            public async Task<CommandJsonRespons> Handle(TestimionalsRemoveCommand request, CancellationToken cancellationToken)
            {

                var response = new CommandJsonRespons();


                if (request.Id == null || request.Id < 1)
                {
                    response.Error = true;
                    response.Message = "Mellumat tamligi qorunmayib";
                    goto end;
                }

                var brand = await db.Testimionalss.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeleteByUserId == null);

                if (brand == null)
                {
                    response.Error = true;
                    response.Message = "Melumat movcud deyildir.";
                    goto end;
                }

                brand.DeleteByUserId = 1;
                brand.DeleteData = DateTime.Now;
                await db.SaveChangesAsync(cancellationToken);

                response.Error = false;
                response.Message = "ugurlu elemlyat";
            end:
                return response;
            }

        }

    }
}
