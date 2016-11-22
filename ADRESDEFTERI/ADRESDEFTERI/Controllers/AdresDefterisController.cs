using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ADRESDEFTERI.Data;
using System.Web.Script.Serialization;

namespace ADRESDEFTERI.Controllers
{
    public class AdresDefterisController : Controller
    {
        private AdresDefteriContext db = new AdresDefteriContext();

        // GET: AdresDefteris
        public ActionResult Index()
        {
            return View(db.AdresDefteri.ToList());
        }

        // GET: AdresDefteris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdresDefteri adresDefteri = db.AdresDefteri.Find(id);
            if (adresDefteri == null)
            {
                return HttpNotFound();
            }
            return View(adresDefteri);
        }

        // GET: AdresDefteris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdresDefteris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TcNo,Ad,SoyAd,DogumTarihi,Adres,Telefon,Enlem,Boylam")] AdresDefteri adresDefteri)
        {
            //koordinatlar google api ile bulunup veritabanına kaydedilecek.
            string koordinat = koordinatBul(adresDefteri.Adres);

            if (ModelState.IsValid)
            {
                db.AdresDefteri.Add(adresDefteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adresDefteri);
        }

        // GET: AdresDefteris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdresDefteri adresDefteri = db.AdresDefteri.Find(id);
            if (adresDefteri == null)
            {
                return HttpNotFound();
            }
            return View(adresDefteri);
        }

        // POST: AdresDefteris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TcNo,Ad,SoyAd,DogumTarihi,Adres,Telefon,Enlem,Boylam")] AdresDefteri adresDefteri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresDefteri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adresDefteri);
        }

        // GET: AdresDefteris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdresDefteri adresDefteri = db.AdresDefteri.Find(id);
            if (adresDefteri == null)
            {
                return HttpNotFound();
            }
            return View(adresDefteri);
        }

        // POST: AdresDefteris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdresDefteri adresDefteri = db.AdresDefteri.Find(id);
            db.AdresDefteri.Remove(adresDefteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public static string koordinatBul(string yer)
        {

            //Google Maps API key'i buraya ekliyoruz.
            string APIKEY = "AIzaSyAFK0-FMQdcONvt4HFfCsXDVLPNCCyn91Y";

            string boylam;

            string enlem;

            string sonuc = "";

            /*Google Maps'e lokasyon ve API key bilgilerini içeren bir query string gönderecegiz*/
            string Spath = "https://maps.googleapis.com/maps/api/geocode/json?address=" + yer + "&key=" + APIKEY;
            //string Spath = "http://maps.google.com/maps/geo?q=" + yer + "&output=csv&key=" + APIKEY;

            /*Web sayfasına erişim için bir web client nesnesi oluşturuyoruz*/
            WebClient WebCli = new WebClient();

            /*Spath değişkenindeki URL içeriğini yani sorgunun sonucunu virgullerden ayırarak bir array içerisine atıyoruz*/
            string[] SonuclarKumesi = WebCli.DownloadString(Spath).ToString().Split(',');

            //JavaScriptSerializer j = new JavaScriptSerializer();
            //var a = j.Deserialize(SonuclarKumesi, typeof(object));

            /*Sadece arrayin 2. ve 3. elemanlarını kullanmamızın nedeni 2. ve 3. elemanlarda boylam ve enlem değerlerinin
            0. ve 1. elemanlarda lokasyonun bulunup bulunmadığı durum parametrelerinin yer almasıdır.*/
            boylam = SonuclarKumesi.GetValue(2).ToString();
            enlem = SonuclarKumesi.GetValue(3).ToString();

            //sonuc = "Enlem  : " + enlem + "\n" + "Boylam: " + boylam;

            return sonuc;

        }
    }
}
