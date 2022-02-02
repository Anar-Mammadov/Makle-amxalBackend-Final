using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using MediatR;
using MaklerSamxal.WebUI.Application.Products;

namespace MaklerSamxal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IMediator mediator;
        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(ProductsPagedQuery request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }
        public async Task<IActionResult> Details(ProductsSingleQuery query)
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
        public async Task<IActionResult> Create(ProductsCreateComman command)
        {

            Product model = await mediator.Send(command);

            if (model != null)

                return RedirectToAction(nameof(Index));

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductsRemoveCommand request)
        {
            var response = await mediator.Send(request);

            return Json(response);
        }

        public async Task<IActionResult> Edit(ProductsSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }
            ProductsViewModel vm = new ProductsViewModel();

            vm.Id = response.Id;
            vm.Title = response.Title;
            vm.Location = response.Location;
            vm.Price = response.Price;
            vm.ImagePath = response.ImagePath;
            vm.Bed = response.Bed;
            vm.Baths = response.Baths;
            vm.Sqft = response.Sqft;
            vm.Description = response.Description;
            vm.ShopDescription = response.ShopDescription;

            return View(vm);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductsEditCommand command)
        {

            var id = await mediator.Send(command);

            if (id > 0)

                return RedirectToAction(nameof(Index));

            return View(command);



        }
    }
}
