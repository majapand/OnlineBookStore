using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Data;
using OnlineBookStore.Models;

namespace OnlineBookStore.Controllers
{
    public class BookGenresController : Controller
    {
        private readonly OnlineBookStoreContext _context;

        public BookGenresController(OnlineBookStoreContext context)
        {
            _context = context;
        }

        // GET: BookGenres
        public async Task<IActionResult> Index()
        {
            var onlineBookStoreContext = _context.BookGenres.Include(b => b.Book).Include(b => b.Genreid);
            return View(await onlineBookStoreContext.ToListAsync());
        }

        // GET: BookGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookGenres == null)
            {
                return NotFound();
            }

            var bookGenres = await _context.BookGenres
                .Include(b => b.Book)
                .Include(b => b.Genreid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookGenres == null)
            {
                return NotFound();
            }

            return View(bookGenres);
        }

        // GET: BookGenres/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Description");
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "GenreName");
            return View();
        }

        // POST: BookGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,GenreId")] BookGenres bookGenres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookGenres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Description", bookGenres.BookId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "GenreName", bookGenres.GenreId);
            return View(bookGenres);
        }

        // GET: BookGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookGenres == null)
            {
                return NotFound();
            }

            var bookGenres = await _context.BookGenres.FindAsync(id);
            if (bookGenres == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Description", bookGenres.BookId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "GenreName", bookGenres.GenreId);
            return View(bookGenres);
        }

        // POST: BookGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,GenreId")] BookGenres bookGenres)
        {
            if (id != bookGenres.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookGenres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookGenresExists(bookGenres.Id))
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
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Description", bookGenres.BookId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "GenreName", bookGenres.GenreId);
            return View(bookGenres);
        }

        // GET: BookGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookGenres == null)
            {
                return NotFound();
            }

            var bookGenres = await _context.BookGenres
                .Include(b => b.Book)
                .Include(b => b.Genreid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookGenres == null)
            {
                return NotFound();
            }

            return View(bookGenres);
        }

        // POST: BookGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookGenres == null)
            {
                return Problem("Entity set 'OnlineBookStoreContext.BookGenres'  is null.");
            }
            var bookGenres = await _context.BookGenres.FindAsync(id);
            if (bookGenres != null)
            {
                _context.BookGenres.Remove(bookGenres);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookGenresExists(int id)
        {
          return (_context.BookGenres?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
