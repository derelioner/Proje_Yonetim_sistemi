using ProjeYonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeYonetim.Controllers
{
    public class ProjeDurumController : Controller
    {

        Service.AppService service = new Service.AppService();
        [HttpGet]
        public ActionResult Liste()
        {
            return View(service.ProjeDurumlariListele());
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(ProjeDurumlari projeDurum)
        {
            var durum = service.ProjeDurumEkle(projeDurum);
            if (durum)
                return RedirectToAction("Liste");

            return View();
        }

        [HttpGet]
        public ActionResult Duzenle(int Id)
        {
            return View(service.ProjeDurumGetir(Id));
        }
        [HttpPost]
        public ActionResult Duzenle(int Id, ProjeDurumlari projeDurum)
        {
            var durum = service.ProjeDurumGuncelle(projeDurum);
            if (durum)
                return RedirectToAction("Liste");

            return View();
        }

        [HttpPost]
        public JsonResult Sil(int Id)
        {
            var result = Core.ProjeRepository.ProjeDurumSil(Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}