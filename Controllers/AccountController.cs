using Microsoft.AspNetCore.Mvc;
using Lap3_2.Models;
using Lap3_2.Repository;
using Lap3_2.ViewModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
namespace Lap3_2.Controllers
{
    public class AccountController : Controller
    {
        IUserRepo db;
        public AccountController(IUserRepo _db)
        {
            
            db = _db;
        }
        public IActionResult Index()
        {
           var model =  db.GetAll();
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User model)
        {
            db.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var res = db.GetById(model);
            if (res == null)
            {
                ModelState.AddModelError("", "UserName and Password Not Valid");
                return View(model);
            }
            Claim c1 = new Claim(ClaimTypes.Name, res.Name);
            Claim c2 = new Claim (ClaimTypes.Email, res.Email);

            ClaimsIdentity ci = new ClaimsIdentity("Cookies");
            ci.AddClaim(c1);
            ci.AddClaim(c2);
            ClaimsPrincipal cp = new ClaimsPrincipal();
            cp.AddIdentity(ci);

            await HttpContext.SignInAsync(cp);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
           await HttpContext.SignOutAsync();
            return RedirectToAction("Index" , "Home");
        }
    }
}
