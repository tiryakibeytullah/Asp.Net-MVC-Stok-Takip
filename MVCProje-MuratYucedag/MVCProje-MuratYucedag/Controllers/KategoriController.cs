using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProje_MuratYucedag.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCProje_MuratYucedag.Controllers
{
    public class KategoriController : Controller
    {
        MVCStokDbEntities db = new MVCStokDbEntities();
        public ActionResult Kategori(int? sayfaNo)
        {
            //var kategoriList = db.TBLKategoriler.ToList();
            int _sayfaNo = sayfaNo ?? 1;
            var kategoriList = db.TBLKategoriler.ToList().ToPagedList(_sayfaNo, 4);

            return View(kategoriList);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKategoriler newKategori)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }

            db.TBLKategoriler.Add(newKategori);
            db.SaveChanges();

            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            var silinecekKategori = db.TBLKategoriler.Find(id);

            db.TBLKategoriler.Remove(silinecekKategori);
            db.SaveChanges();
            return RedirectToAction("Kategori");
        }

        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var guncellenicekKategori = db.TBLKategoriler.Find(id);

            return View("KategoriGuncelle",guncellenicekKategori);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(TBLKategoriler guncellenicekKategori)
        {
            var kategori = db.TBLKategoriler.Where(x => x.KategoriId == guncellenicekKategori.KategoriId).SingleOrDefault();

            kategori.KategoriAd = guncellenicekKategori.KategoriAd;
            db.SaveChanges();

            return RedirectToAction("Kategori");
        }


    }
}