using CoreProject_Departman.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject_Departman.Controllers
{
    public class Personeller : Controller
    {

        Context c = new Context();

  
        public IActionResult Index()
        {
            var values = c.Personels.Include(x => x.Birim).ToList();
            return View(values);
        }

        //YeniPersonel
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> values = (from x in c.Birims.ToList() select new SelectListItem
            { Text = x.BirimAd, Value = x.BirimID.ToString() }).ToList();
            ViewBag.birim = values;
                return View();
        }
        
        [HttpPost]
        public IActionResult YeniPersonel(Personel p)
        {
            //Dropdowndaki veriyi ekleme
            var birim = c.Birims.Where(x => x.BirimID == p.Birim.BirimID).FirstOrDefault();
            p.Birim = birim;

            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PersonelSil(int id)
        {
            var values = c.Personels.Find(id);
            c.Personels.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        //ID'YE GÖRE PERSONEL DEĞERLERİNİ GETİR
        public IActionResult PersonelDeger(int id)
        {
            var values = c.Personels.Find(id);
            return View("PersonelDeger", values);
        }

        public IActionResult PersonelGuncelle(Personel d)
        {
            var values = c.Personels.Find(d.PersonelID);
            values.PersonelAd = d.PersonelAd;
            values.PersonelSoyad = d.PersonelSoyad;
            values.PersonelSehir = d.PersonelSehir;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
