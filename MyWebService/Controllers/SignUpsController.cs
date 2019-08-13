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
    public class signUpsController : Controller
    {
        private readonly MyWebServiceContext _context;

        public signUpsController(MyWebServiceContext context)
        {
            _context = context;
        }

        // GET: signUps
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: signUps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUp = await _context.SignUp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signUp == null)
            {
                return NotFound();
            }

            return View(signUp);
        }

        // GET: signUps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: signUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,CPF,CNPJ,HomePhone,Phone,Username,Password,ZipCode,Number")] SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signUp);
        }

        // GET: signUps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUp = await _context.SignUp.FindAsync(id);
            if (signUp == null)
            {
                return NotFound();
            }
            return View(signUp);
        }

        // POST: signUps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] SignUp signUp)
        {
            if (id != signUp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!signUpExists(signUp.Id))
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
            return View(signUp);
        }

        // GET: signUps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUp = await _context.SignUp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signUp == null)
            {
                return NotFound();
            }

            return View(signUp);
        }

        // POST: signUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signUp = await _context.SignUp.FindAsync(id);
            _context.SignUp.Remove(signUp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool signUpExists(int id)
        {
            return _context.SignUp.Any(e => e.Id == id);
        }
    }
}
