using CoreProject_Departman.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreProject_Departman.Controllers
{
    public class Login : Controller
    {

        Context c = new Context();

        public IActionResult Loginin()
        {
            return View();
        }


        public async Task<IActionResult> Loginin(Admin adm)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == adm.KullaniciAd && x.Sifre == adm.Sifre);
            if (bilgiler !=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,adm.KullaniciAd)
                };
                var useridentitiy = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentitiy);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Personeller");
            }
            return View();
        }
    }
}
