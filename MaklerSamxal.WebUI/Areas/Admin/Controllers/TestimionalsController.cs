using MaklerSamxal.WebUI.Application.TestimionalsS;
using MaklerSamxal.WebUI.Models.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimionalsController : Controller
    {


        private readonly IMediator mediator;
        public TestimionalsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(TestimionalsPagedQuery request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }
        public async Task<IActionResult> Details(TestimionalsSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestimionalsCreateComman command)
        {

            Testimionals model = await mediator.Send(command);

            if (model != null)

                return RedirectToAction(nameof(Index));

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TestimionalsRemoveCommand request)
        {
            var response = await mediator.Send(request);

            return Json(response);
        }

        public async Task<IActionResult> Edit(TestimionalsSingleQuery query)
        {
            var respons = await mediator.Send(query);

            if (respons == null)
            {
                return NotFound();
            }
            TestimionalsViewModel vm = new TestimionalsViewModel();

            vm.Id = respons.Id;
            vm.ImagePath = respons.ImagePath;
            vm.FullName = respons.FullName;
            vm.Customer = respons.Customer;
            vm.Desription = respons.Desription;

            return View(vm);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TestimionalsEditCommand command)
        {

            var id = await mediator.Send(command);

            if (id > 0)

                return RedirectToAction(nameof(Index));

            return View(command);



        }

    }
}
