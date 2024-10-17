using EFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Controllers
{
    public class KursKayitController : Controller
    {
        private readonly DataContext _context;
        public KursKayitController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // include metodu ile ilişkili kayıtların verileri çekilebilir modele
            var kurskayitleri=await _context.KursKayitlari.Include(x=>x.Ogrenci).Include(x=>x.Kurs).ToListAsync();
            return View(kurskayitleri);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(),"Id", "AdSoyad");
            ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(),"Id", "Baslik");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KursKayit kursKayit)
        {
            kursKayit.KayitTarihi = DateTime.Now;
            _context.KursKayitlari.Add(kursKayit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
