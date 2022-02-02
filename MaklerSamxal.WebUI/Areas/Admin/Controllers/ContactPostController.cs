using MaklerSamxal.WebUI.Application.Core;
using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ContactPostController : Controller
    {

        readonly MaklerSamxalDbContext db;
        readonly IConfiguration configuration;



        public ContactPostController(MaklerSamxalDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }
        public async Task<IActionResult> Index(int typeId)
        {
            var query = db.Contacts.AsQueryable()
                .Where(cp => cp.DeleteByUserId == null);


            ViewBag.query = query.Count();
            ViewBag.Count = query.Where(cp => cp.AnswerByUserId == null).Count();
            ViewBag.Count1 = query.Where(cp => cp.AnswerByUserId != null).Count();

            switch (typeId)
            {
                case 1:
                    query = query.Where(cp => cp.AnswerByUserId == null);
                    break;
                case 2:
                    query = query.Where(cp => cp.AnswerByUserId != null);
                    break;
                default:
                    break;
            }
            return View(await query.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPost = await db.Contacts
                .FirstOrDefaultAsync(m => m.Id == id
                && m.DeleteByUserId == null
                && m.AnswerByUserId == null);

            if (contactPost == null)
            {
                return NotFound();
            }

            return View(contactPost);
        }
        [HttpPost]
        public async Task<IActionResult> Answer([Bind("Id", "Answer")] Contact model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var contactPost = await db.Contacts
                .FirstOrDefaultAsync(m => m.Id == model.Id
                && m.DeleteByUserId == null
                && m.AnswerByUserId == null);

            if (contactPost == null)
            {
                return NotFound();
            }

            contactPost.Answer = model.Answer;
            contactPost.AnswerData = DateTime.Now;
            contactPost.AnswerByUserId = 1;

            string token = $"subscribetoken-{model.Id}-{DateTime.Now:yyyyMMddHHmmss}"; // token yeni id götürürük

            token = token.Encrypt("");

            string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirm?token={token}"; // path düzəldirik



            var mailSended = configuration.SendEmail(contactPost.Email, "MaklerSamxal", $"Sorğunuza cavab gəldi  `{model.Answer}` ");


            await db.SaveChangesAsync();
            return Redirect(nameof(Index));
        }
    }

}
