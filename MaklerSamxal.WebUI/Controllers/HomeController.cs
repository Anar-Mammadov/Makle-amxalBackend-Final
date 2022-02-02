using MaklerSamxal.WebUI.Application.Core;
using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using MaklerSamxal.WebUI.Models.Entity.Membership;
using MaklerSamxal.WebUI.Models.FormModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        readonly MaklerSamxalDbContext db;
        readonly IConfiguration configuration;
        readonly UserManager<MaklerUser> userManager;
        readonly SignInManager<MaklerUser> signInManager;
        public HomeController(MaklerSamxalDbContext db, IConfiguration configuration, UserManager<MaklerUser> userManager, SignInManager<MaklerUser> signInManager)
        {
            this.db = db;
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About(Testimionals testimionals)
        {
            var data = db.Testimionalss.Where(d => d.DeleteByUserId == null).ToList();

            return View(data);
        }
        public IActionResult Agents(Agent agents)
        {
            var data = db.Agents.Where(d => d.DeleteByUserId == null).ToList();

            return View(data);
            
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact model)
        {

            if (ModelState.IsValid)
            {
                db.Contacts.Add(model);
                db.SaveChanges();

                return Json(new
                {
                    error = false,
                    message = "Sorğunuz qeydə alındı."
                });


            }

            return Json(new
            {
                error = true,
                message = "Sorğunuz qeydə alınmadı."
            });

        }



        [HttpGet]
        public IActionResult Register()
        {
            //Eger giriş edibsə routeda myaccount/sign yazanda o səhifə açılmasın ana səhifəyə yönlənsin
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel register)
        {

            //giriş edilibsə home a atsın
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Yeni user yaradırıq
            MaklerUser user = new MaklerUser
            {

                UserName = register.UserName,
                Email = register.Email,
                Activates = true
            };



            string token = $"subscribetoken-{register.UserName}-{DateTime.Now:yyyyMMddHHmmss}"; // token yeni id götürürük

            token = token.Encrypt("");

            string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirmm?token={token}"; // path düzəldirik



            var mailSended = configuration.SendEmail(user.Email, "MaklerŞamxal Səhifəsi", $"Zəhmət olmasa <a href={path}>Link</a> vasitəsi ilə abunəliyi tamamlayın");


            var person = await userManager.FindByNameAsync(user.UserName);

                
            if (person == null)
            {
                // userManager vasitəs ilə user ve RegistrVM password yoxluyuruq və yaradırıq
                var identityRuselt = await userManager.CreateAsync(user, register.Password);


                //Startupda yazdığımız qanunlara uymursa Configure<IdentityOptions> onda error qaytarırıq summary ilə.
                if (!identityRuselt.Succeeded)
                {
                    foreach (var error in identityRuselt.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                //Yaratdığımız user ilk yarananda user rolu veririk.

                await userManager.AddToRoleAsync(user, "User");

                return RedirectToAction("Signin", "Home");

            }


            if (person.UserName != null)
            {
                ViewBag.ms = "Bu username öncədən qeydiyyatdan keçib";

                return View(register);
            }
            return null;

        }

        public IActionResult Signin()
        {
           // əgər giriş olubusa ana səhifəyə göndərsin
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Signin(LoginFormModel user)
        {


            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }

            if (ModelState.IsValid)
            {

                MaklerUser founderUser = null;

                if (user.UserName.IsEmail())
                {
                    founderUser = await userManager.FindByEmailAsync(user.UserName); //Email axtarış 
                }
                else
                {
                    founderUser = await userManager.FindByNameAsync(user.UserName); //UserName axtarış

                }

                if (founderUser == null) // view göndərir yeni isdifadəçi tapılmıyanda
                {
                    ViewBag.Ms = "İstifadəçi adı və ya şifrə səhvdir.";
                    return View(user);

                }

                if (founderUser.EmailConfirmed == false)
                {
                    ViewBag.Ms = "Zəhmət olmasa e-mailinizi təsdiq edin.";
                    return View(user);
                }

                //Əgər istifadəçi user deyilsə onda girə bilməz.

                if (!await userManager.IsInRoleAsync(founderUser, "User"))
                {
                    ViewBag.Ms = "İstifadəçi adı və ya parol səhvdir.";
                    return View(user);
                }




                if (founderUser.Activates == false)
                {
                    ViewBag.ms = "Siz admin tərəfindən banlanmısınız";
                    return View(user);
                }

                if (founderUser.Activates == true)
                {
                    var sRuselt = await signInManager.PasswordSignInAsync(founderUser, user.Password, true, true); //Burda giriş edirik.

                    if (sRuselt.Succeeded != true) // Əgər girə bilmirsə
                    {
                        ViewBag.Ms = "İstifadəçi adı və ya parol səhvdir.";
                        return View(user);

                    }
                    var redirectUrl = Request.Query["ReturnUrl"];

                    if (!string.IsNullOrWhiteSpace(redirectUrl))
                    {
                        return Redirect(redirectUrl);
                    }

                    return RedirectToAction("Index", "Home");

                }
            }

            ViewBag.Ms = "Zəhmət olmasa məlumatları doldurun.";
            return View(user);
        }


        [HttpPost]
        [Route("/Subscrice.html")]
        public IActionResult Subscrice([Bind("Email")] Subscrice model)
        {

            if (ModelState.IsValid)
            {
                var current = db.Subscrices.FirstOrDefault(s => s.Email.Equals(model.Email));
                if (current != null && current.EmailConfirmed == true)
                {
                    return Json(new
                    {

                        error = true,
                        massege = "Bu E-Mail öncədən qeydiyyatdan keçib"

                    });
                }
                else if (current != null && (current.EmailConfirmed ?? false == false))
                {
                    return Json(new
                    {

                        error = true,
                        massege = "Bu E-Mail öncədən qeydiyyatdan keçib"

                    });
                }


                db.Subscrices.Add(model);
                db.SaveChanges();


                string token = $"subscribetoken-{model.Id}-{DateTime.Now:yyyyMMddHHmmss}"; // token yeni id götürük

                token = token.Encrypt("");

                string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirm?token={token}"; // path yaradırıq



                var mailSended = configuration.SendEmail(model.Email, "MaklerŞamxal Səhifəsi ", $"Siz yeni məlumatlardan xəbərdar olacaqsınız.");
                if (mailSended == false)
                {
                    db.Database.RollbackTransaction();

                    return Json(new
                    {
                        error = false,
                        massege = "E-mail göndərilməsi zamanı xəta baş verdi!"

                    });
                }

                return Json(new
                {

                    error = false,
                    massege = "Sorğunuz uğurla qeydə alındı.!"

                });
            }



            return Json(new
            {

                error = true,
                massege = "Sorğunuzun icrası zamanı xəta yarandı.Zəhmət olmasa yenidən yoxlayın."

            });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("subscribe-confirmm")]
        public IActionResult SubscibeConfirm(string token)
        {


            token = token.Decrypte("");

            Match match = Regex.Match(token, @"subscribetoken-(?<id>[a-zA-Z0-9]*)(.*)-(?<timeStampt>\d{14})");

            if (match.Success)
            {
                string id = match.Groups["id"].Value;
                string executeTimeStamp = match.Groups["executeTimeStamp"].Value;

                var subsc = db.Users.FirstOrDefault(s => s.UserName == id);

                if (subsc == null)
                {
                    ViewBag.ms = Tuple.Create(true, "Token xətasi");
                    goto end;
                }
                if (subsc.EmailConfirmed == true)
                {
                    ViewBag.ms = Tuple.Create(true, "Artıq təsdiq edildi");
                    goto end;
                }
                subsc.EmailConfirmed = true;
                db.SaveChanges();

                ViewBag.ms = Tuple.Create(false, "Abunəliyiniz təsdiq edildi");

            }
        end:
            return View();
        }



        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Signin));
        }


        public IActionResult Accessdenied()
        {
            return View();
        }
    }
}
