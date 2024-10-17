using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCoreApp.Data;

namespace EFCoreApp.Controllers
{
    public class OgretmenController : Controller
    {
        private readonly DataContext _context;

        public OgretmenController(DataContext context)
        {
            _context = context;
        }

        // GET: Ogretmen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ogretmenler.ToListAsync());
        }

        // GET: Ogretmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        // GET: Ogretmen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ogretmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ogretmenAd,ogretmenSoyd,ogretmenMail,ogretmenTel,BaslamaTarihi")] Ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogretmen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ogretmen);
        }

        // GET: Ogretmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmen = await _context
                .Ogretmenler

                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogretmen == null)
            {
                return NotFound();
            }
            return View(ogretmen);
        }

        // POST: Ogretmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ogretmenAd,ogretmenSoyd,ogretmenMail,ogretmenTel,BaslamaTarihi")] Ogretmen ogretmen)
        {
            if (id != ogretmen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogretmen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgretmenExists(ogretmen.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ogretmen);
        }

        // GET: Ogretmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        // POST: Ogretmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if (ogretmen != null)
            {
                _context.Ogretmenler.Remove(ogretmen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgretmenExists(int id)
        {
            return _context.Ogretmenler.Any(e => e.Id == id);
        }
    }
}
