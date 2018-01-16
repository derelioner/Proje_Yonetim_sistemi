using ProjeYonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeYonetim.Controllers
{

    public class KullaniciController : Controller
    {
        Service.AppService service = new Service.AppService();
        [HttpGet]
        public ActionResult Liste()
        {
            return View(service.KullaniciListele());
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Kullanicilar kullanici)
        {
            var durum = service.KullaniciEkle(kullanici);
            if (durum)
                return RedirectToAction("Liste");

            return View();
        }

        [HttpGet]
        public ActionResult Duzenle(int Id)
        {
            return View(service.KullaniciGetir(Id));
        }
        [HttpPost]
        public ActionResult Duzenle(int Id, Kullanicilar kullanici)
        {
            var durum = service.KullaniciGuncelle(kullanici);
            if (durum)
                return RedirectToAction("Liste");

            return View();
        }

        [HttpPost]
        public JsonResult Sil(int Id)
        {
            var result = Core.ProjeRepository.KullaniciSil(Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}