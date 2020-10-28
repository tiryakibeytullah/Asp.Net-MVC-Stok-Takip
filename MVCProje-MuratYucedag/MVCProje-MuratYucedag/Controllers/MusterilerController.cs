using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProje_MuratYucedag.Models.Entity;

namespace MVCProje_MuratYucedag.Controllers
{
    public class MusterilerController : Controller
    {
        MVCStokDbEntities db = new MVCStokDbEntities();
        // GET: Musteriler
        public ActionResult Musteriler(string nick)
        {
            var degerler = from d in db.TBLMusteriler select d;
            if (!string.IsNullOrEmpty(nick))
            {
                degerler = degerler.Where(x => x.MusteriAd.Contains(nick));
            }
            return View(degerler.ToList());

            //var musterilerList = db.TBLMusteriler.ToList();

            //return View(musterilerList);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMusteriler newMusteri)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMusteriler.Add(newMusteri);
            db.SaveChanges();

            return View();
        }
        public ActionResult MusteriSil(int id)
        {
            var silinecekMusteri = db.TBLMusteriler.Find(id);

            db.TBLMusteriler.Remove(silinecekMusteri);
            db.SaveChanges();
            return RedirectToAction("Musteriler");
        }
        [HttpGet]
        public ActionResult MusteriGuncelle(int id)
        {
            var guncellenicekMusteri = db.TBLMusteriler.Find(id);

            return View("MusteriGuncelle", guncellenicekMusteri);
        }
        [HttpPost]
        public ActionResult MusteriGuncelle(TBLMusteriler guncellenicekMusteri)
        {
            var musteri = db.TBLMusteriler.Where(x => x.MusteriId == guncellenicekMusteri.MusteriId).FirstOrDefault();

            musteri.MusteriAd = guncellenicekMusteri.MusteriAd;
            musteri.MusteriSoyad = guncellenicekMusteri.MusteriSoyad;
            db.SaveChanges();

            return RedirectToAction("Musteriler");
        }

    }
}