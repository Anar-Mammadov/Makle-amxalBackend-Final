using MaklerSamxal.WebUI.Application.Ageds;
using MaklerSamxal.WebUI.Models.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AgentsController : Controller
    {
        private readonly IMediator mediator;
        public AgentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(AgentsPagedQuery request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }
        public async Task<IActionResult> Details(AgentsSingleQuery query)
        {
            var respons = await mediator.Send(query);

            if (respons == null)
            {
                return NotFound();
            }

            return View(respons);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgentsCreateComman command)
        {

            Agent model = await mediator.Send(command);

            if (model != null)

                return RedirectToAction(nameof(Index));

            return View(command);
        }
        public async Task<IActionResult> Edit(AgentsSingleQuery query)
        {
            var respons = await mediator.Send(query);

            if (respons == null)
            {
                return NotFound();
            }
            AgentsViewModel vm = new AgentsViewModel();

            vm.Id = respons.Id;
            vm.Position = respons.Position;
            vm.FullName = respons.FullName;
            vm.Instagram = respons.Instagram;
            vm.Facebook = respons.Facebook;
            vm.Twitter = respons.Twitter;
            vm.Linkedin = respons.Linkedin;
            vm.ImagePath = respons.ImagePath;

            return View(vm);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AgentsEditCommand command)
        {

            var id = await mediator.Send(command);

            if (id > 0)

                return RedirectToAction(nameof(Index));

            return View(command);



        }
        public async Task<IActionResult> Delete(AgentsRemoveCommand requst)
        {
            var respons = await mediator.Send(requst);

            return Json(respons);
        }
    }
}
