using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProje_MuratYucedag.Models.Entity;

namespace MVCProje_MuratYucedag.Controllers
{
    public class UrunController : Controller
    {
        MVCStokDbEntities db = new MVCStokDbEntities();

        // GET: Urun
        public ActionResult Urunler()
        {
            var urunlerList = db.TBLUrunler.ToList();

            return View(urunlerList);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> urun = (from x in db.TBLKategoriler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.KategoriAd,
                                                Value = x.KategoriId.ToString()
                                            }).ToList();
            ViewBag.urunler = urun;

            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLUrunler newUrun)
        {
            var kategori = db.TBLKategoriler.Where(x => x.KategoriId == newUrun.TBLKategoriler.KategoriId).FirstOrDefault();
            newUrun.TBLKategoriler = kategori;

            db.TBLUrunler.Add(newUrun);
            db.SaveChanges();

            return RedirectToAction("Urunler"); ;
        }
        public ActionResult UrunSil(int id)
        {
            var silinecekUrun = db.TBLUrunler.Find(id);

            db.TBLUrunler.Remove(silinecekUrun);
            db.SaveChanges();

            return RedirectToAction("Urunler");
        }

        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            var gelenUrun = db.TBLUrunler.Find(id);

            List<SelectListItem> urun = (from x in db.TBLKategoriler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.KategoriAd,
                                             Value = x.KategoriId.ToString()
                                         }).ToList();
            ViewBag.urunler = urun;

            return View("UrunGuncelle",gelenUrun);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(TBLUrunler guncellenicekUrun)
        {
            var urun = db.TBLUrunler.Find(guncellenicekUrun.UrunId);
            urun.UrunAd = guncellenicekUrun.UrunAd;
            urun.UrunMarka = guncellenicekUrun.UrunMarka;
            urun.UrunFiyat = guncellenicekUrun.UrunFiyat;
            urun.UrunStok = guncellenicekUrun.UrunStok;
            //urun.UrunKategori = guncellenicekUrun.UrunKategori;
            var kategori = db.TBLKategoriler.Where(x => x.KategoriId == guncellenicekUrun.TBLKategoriler.KategoriId).FirstOrDefault();
            urun.UrunKategori = kategori.KategoriId;

            db.SaveChanges();
            return RedirectToAction("Urunler");
        }
    }
}