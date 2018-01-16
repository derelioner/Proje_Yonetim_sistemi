using ProjeYonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeYonetim.Controllers
{
    public class ProjeController : Controller
    {
        Service.AppService service = new Service.AppService();
        [HttpGet]
        public ActionResult Liste()
        {
            return View(service.ProjeListele());
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Projeler proje)
        {
            var durum = service.ProjeEkle(proje);
            if (durum)
                return RedirectToAction("Liste");

            return View();
        }

        [HttpGet]
        public ActionResult Duzenle(int Id)
        {
            return View(service.ProjeGetir(Id));
        }
        [HttpPost]
        public ActionResult Duzenle(int Id, Projeler proje)
        {
            var durum = service.ProjeGuncelle(proje);
            if (durum)
                return RedirectToAction("Liste");

            return View();
        }

        [HttpPost]
        public JsonResult Sil(int Id)
        {
            var result = Core.ProjeRepository.ProjeSil(Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}