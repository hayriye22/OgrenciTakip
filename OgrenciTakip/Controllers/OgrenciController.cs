using Microsoft.AspNetCore.Mvc;
using OgrenciTakip.Models;

namespace OgrenciTakip.Controllers
{
    public class OgrenciController : Controller
    {
        static List<OgrenciModel> ogrenciler = new List<OgrenciModel>();
        
        public IActionResult Index()
        {      
            return View();
        }
        [HttpGet]
        public IActionResult Kayit(OgrenciModel ogrenci)
        {
            if (ogrenci.OgrenciNo < 1)
            {
                return Content(" Öğrenci numarası geçerli değil.");
            }
            else if (string.IsNullOrEmpty(ogrenci.Adi))
            {
                return Content("ögrenci adı geçerli değil");
            }
            else if (string.IsNullOrEmpty(ogrenci.SoyAdi))
            {
                return Content("ogrenci soyadı geçerli değil");
            }
            else if (string.IsNullOrEmpty(ogrenci.Sinifi))
            {
                return Content("ogrenci sınıfını giriniz lütfen");
            }
            else
            {
                ogrenciler.Add(ogrenci);
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public IActionResult Listele(OgrenciModel ogrenci)
        {
            return View(ogrenciler);
        }
    }
}
