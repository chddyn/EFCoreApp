using EFCoreApp.Data;
using EFCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Controllers
{
    public class KursController : Controller
    {
        private readonly DataContext _context;

        public KursController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var kurslar = await _context.Kurslar.Include(o => o.Ogretmen).ToListAsync();
            return View(kurslar);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "ogretmenAdSoyad");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(KursViewModel model)
        {
            if (ModelState.IsValid)
            {
                //kursview model kullandığımız için new ile kursa erişiyoruz çünkü bizden bir kurs model bekleniyor
                _context.Kurslar.Add(new Kurs() { Id = model.Id, Baslik = model.Baslik, ogretmenId = model.ogretmenId });
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
          return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kurs = await _context.Kurslar
                .Include(c => c.kursKayitlari)
                .ThenInclude(o => o.Ogrenci) // bu sefer kursa kayıtlı öğrencileri çekiyoruz
                .Select(k=>new KursViewModel
                {
                    Id= k.Id,
                    Baslik=k.Baslik,
                    ogretmenId=k.ogretmenId,
                    kursKayitlari=k.kursKayitlari
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (kurs == null)
            {
                return NotFound();
            }

            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "Id", "ogretmenAdSoyad");


            return View(kurs);
        }



        [HttpPost]
        [ValidateAntiForgeryToken] // formu gönderen ile güncellemeyi yapan aynı kişi mi linki alıp başka yerde kullanmasınlar

        public async Task<IActionResult> Edit(int id, KursViewModel model)
        {

            if (id != model.Id)
            {
                return NotFound();

            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(new Kurs() {Id=model.Id,Baslik=model.Baslik,ogretmenId=model.ogretmenId});
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    if (!_context.Kurslar.Any(x => x.Id == model.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {

                return NotFound();

            }

            var kurs = await _context.Kurslar.FindAsync(id);

            if (kurs == null)
            {
                return NotFound();
            }



            return View(kurs);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            var kurs = await _context.Kurslar.FindAsync(id);

            if (kurs == null)
            { return NotFound(); }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Remove(kurs);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    if (!_context.Kurslar.Any(x => x.Id == kurs.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }


            }
            return RedirectToAction("Index");

        }


    }
}