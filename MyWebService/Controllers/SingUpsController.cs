using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebService.Models;

namespace MyWebService.Controllers
{
    public class SingUpsController : Controller
    {
        private readonly MyWebServiceContext _context;

        public SingUpsController(MyWebServiceContext context)
        {
            _context = context;
        }

        // GET: SingUps
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: SingUps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singUp = await _context.SingUp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (singUp == null)
            {
                return NotFound();
            }

            return View(singUp);
        }

        // GET: SingUps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SingUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,CPF,CNPJ,HomePhone,Phone,Username,Password,ZipCode,Number")] SingUp singUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(singUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(singUp);
        }

        // GET: SingUps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singUp = await _context.SingUp.FindAsync(id);
            if (singUp == null)
            {
                return NotFound();
            }
            return View(singUp);
        }

        // POST: SingUps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] SingUp singUp)
        {
            if (id != singUp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(singUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SingUpExists(singUp.Id))
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
            return View(singUp);
        }

        // GET: SingUps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singUp = await _context.SingUp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (singUp == null)
            {
                return NotFound();
            }

            return View(singUp);
        }

        // POST: SingUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var singUp = await _context.SingUp.FindAsync(id);
            _context.SingUp.Remove(singUp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SingUpExists(int id)
        {
            return _context.SingUp.Any(e => e.Id == id);
        }
    }
}
