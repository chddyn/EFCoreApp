using EFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
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
            var kurslar = await _context.Kurslar.ToListAsync(); 
            return View(kurslar);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Kurs model)
        {
            _context.Kurslar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
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
        [ValidateAntiForgeryToken] // formu gönderen ile güncellemeyi yapan aynı kişi mi linki alıp başka yerde kullanmasınlar

        public async Task<IActionResult> Edit(int id, Kurs model)
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
