using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProje_MuratYucedag.Models.Entity;

namespace MVCProje_MuratYucedag.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MVCStokDbEntities db = new MVCStokDbEntities();
        public ActionResult Satislar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBLSatislar satis)
        {
            db.TBLSatislar.Add(satis);
            db.SaveChanges();

            return View("Satislar");
        }
    }
}