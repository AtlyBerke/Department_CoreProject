using CoreProject_Departman.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject_Departman.Controllers
{
    public class Birimler : Controller
    {

        Context c = new Context();

        public IActionResult Index()
        {
            //BİRİM LİSTESİ
            var values = c.Birims.ToList();
            return View(values);
        }

        //YENİBİRİM
        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {
            c.Birims.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        //BİRİM SİL
        public IActionResult BirimSil(int id)
        {
            var values = c.Birims.Find(id);
            c.Birims.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        //ID'YE GÖRE DEPARTMAN DEĞERLERİNİ GETİR
        public IActionResult BirimDeger(int id)
        {
            var values = c.Birims.Find(id);
            return View("BirimDeger", values);
        }

        public IActionResult BirimGuncelle(Birim d)
        {
            var values = c.Birims.Find(d.BirimID);
            values.BirimAd = d.BirimAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BirimDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.BirimID == id).ToList();
            var birimad = c.Personels.Where(x => x.BirimID == id).Select(y => y.Birim.BirimAd).FirstOrDefault();
            ViewBag.ba = birimad;
            return View(degerler);
        }
    }
}
