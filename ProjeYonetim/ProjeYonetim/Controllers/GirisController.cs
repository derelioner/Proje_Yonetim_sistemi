using ProjeYonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeYonetim.Controllers
{
    public class GirisController : Controller
    {
        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(Kullanicilar kullanici)
        {
            var item = Core.ProjeRepository.Giris(kullanici.KullaniciAdi, kullanici.Sifre);
            if (item != null)
            {
                Session["Kullanici"] = item.KullaniciAdi;
                Session.Timeout = 5000;
                return RedirectToAction("Liste", "Proje");
            }
            else
            {
                ViewBag.Hata = "Hatalı Kullanıcı Adı veya Şifre";
            }
            return View();
        }

        [HttpGet]
        public ActionResult OturumuKapat()
        {
            Session.Abandon();
            return View("Giris");
        }
    }
}