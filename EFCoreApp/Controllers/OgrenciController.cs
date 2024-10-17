using EFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly DataContext _context;

        public OgrenciController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _context.Ogrenciler.ToListAsync();

            return View(ogrenciler);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ogrencı = await _context.Ogrenciler.Include(m=>m.kursKayitlari)
                .ThenInclude(o=>o.Kurs) // önce öğrencileri include eder sonra öğrencilere göre kursu include eder normal include hata verir
                .FirstOrDefaultAsync(x=>x.Id==id);

            if (ogrencı == null)
            {
                return NotFound();
            }

            return View(ogrencı);
        }


        [HttpPost]
        [ValidateAntiForgeryToken] // formu gönderen ile güncellemeyi yapan aynı kişi mi linki alıp başka yerde kullanmasınlar

        public async Task<IActionResult> Edit(int id, Ogrenci model)
        {

            if (id != model.Id)
            {
                return NotFound();

            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    if (!_context.Ogrenciler.Any(x => x.Id == model.Id))
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

            var ogrenci = await _context.Ogrenciler.FindAsync(id);

            if (ogrenci == null)
            {
                return NotFound();
            }



            return View(ogrenci);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);

            if (ogrenci == null)
            { return NotFound(); }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Remove(ogrenci);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    if (!_context.Ogrenciler.Any(x => x.Id == ogrenci.Id))
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
