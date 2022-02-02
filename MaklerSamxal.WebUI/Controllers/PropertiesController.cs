using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Controllers
{
    public class PropertiesController : Controller
    {
        readonly MaklerSamxalDbContext db;
        public PropertiesController(MaklerSamxalDbContext db)
        {
            this.db = db;
        }
        [AllowAnonymous]
        public IActionResult Index(Product product)
        {
            var data = db.Products.Where(d => d.DeleteByUserId == null).ToList();

            return View(data);

        }
        public IActionResult Details(int id)
        {
            var data = db.Products.FirstOrDefault(d => d.Id == id);

            return View(data);
       
        }
    }
}
