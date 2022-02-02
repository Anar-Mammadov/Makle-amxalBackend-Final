using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Controllers
{
    public class BlogController : Controller
    {
        readonly MaklerSamxalDbContext db;


        public BlogController(MaklerSamxalDbContext db)
        {
            this.db = db;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var data = db.Blogs.Where(b => b.DeleteByUserId == null).ToList();
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = db.Blogs
                    .Include(m => m.CreateByUser)
                    .Include(m => m.Comments)
                    .ThenInclude(m => m.CreateByUser)
                    .Include(m => m.Comments)
                    .ThenInclude(m => m.Children)
                    .FirstOrDefault(b => b.Id == id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> PostComment(int? commentId, int postId, string comment)
        {
            if (string.IsNullOrWhiteSpace(comment))
            {
                return Json(new
                {
                    error = true,
                    message = "Şərh boş buraxıla bilməz!"
                });
            }

            if (postId < 1)
            {
                return Json(new
                {
                    error = true,
                    message = "Post mövcud deyil!"
                });
            }


            var post = await db.Blogs.FirstOrDefaultAsync(c => c.Id == postId);


            if (post == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Post mövcüd deyil!"
                });
            }

            var commentModel = new BlogPostComment
            {
                ParentId = commentId,
                BlogPostId = postId,
                Comment = comment,
                CreateByUserId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)
            };
            if (commentId.HasValue && await db.BlogPostComments.AnyAsync(c => c.Id == commentId))
                commentModel.ParentId = commentId;

            await db.BlogPostComments.AddAsync(commentModel);
            await db.SaveChangesAsync();



            commentModel = await db.BlogPostComments
                .Include(c => c.CreateByUserId)
                .Include(c => c.Parent)
                .FirstOrDefaultAsync(c => c.Id == commentModel.Id);

            return PartialView("_Comment", commentModel);
        }

    }
}
