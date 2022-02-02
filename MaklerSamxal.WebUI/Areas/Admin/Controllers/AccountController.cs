using MaklerSamxal.WebUI.Application.Core;
using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity.Membership;
using MaklerSamxal.WebUI.Models.FormModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class AccountController : Controller
    {
        readonly UserManager<MaklerUser> userManager;
        readonly SignInManager<MaklerUser> signInManager;
        readonly MaklerSamxalDbContext db;
        public AccountController(UserManager<MaklerUser> userManager, SignInManager<MaklerUser> signInManager, MaklerSamxalDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
        }
        [AllowAnonymous]
        public IActionResult Singin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Singin(LoginFormModel user)
        {

            if (ModelState.IsValid)
            {

                MaklerUser founderUser = null;

                if (user.UserName.IsEmail())
                {
                    founderUser = await userManager.FindByEmailAsync(user.UserName); //email axtarış
                }
                else
                {
                    founderUser = await userManager.FindByNameAsync(user.UserName); //username axtarış

                }

                if (founderUser == null) //login ola bilmirsə viev göndərir
                {
                    ViewBag.Ms = "İstifadəçi adı və ya şifrə yanlışdır.";
                    return View(user);

                }

                var rIds = db.UserRoles.Where(ur => ur.UserId == founderUser.Id).Select(ur => ur.RoleId).ToArray();//   UserRole id istifadəçilərin rolu id bərabərdirsə  bizə role Id versin


                var hasAnotherRole = db.Roles.Where(r => !r.Name.Equals("USER") && rIds.Contains(r.Id)).Any();// yalnız userrolu varsa giriş edə bilməsin


                if (hasAnotherRole == false) //yalnız user rolu varsa
                {

                    ViewBag.Ms = "İstifadəçi adı və ya şifrə yanlışdır.";
                    return View(user);
                }





                var sRuselt = await signInManager.PasswordSignInAsync(founderUser, user.Password, true, true); // giriş edirik


                if (sRuselt.Succeeded != true) //giriş uğurlu deyilsə
                {
                    ViewBag.Ms = "İstifadəçi adı və ya şifrə yanlışdır.";
                    return View(user);

                }
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.Ms = "Zəhmət olmasa doldurun.";
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Singin));

        }
    }
}
