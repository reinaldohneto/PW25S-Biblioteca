using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class LivroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Livro
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LivroModel.Include(l => l.Autor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Livro/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroModel = await _context.LivroModel
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livroModel == null)
            {
                return NotFound();
            }

            return View(livroModel);
        }

        // GET: Livro/Create
        public IActionResult Create()
        {
            ViewData["Nome"] = new SelectList(_context.AutorModel, "NomeAutor", "NomeAutor");
            return View();
        }

        // POST: Livro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Ano,NomeAutor,DataCadastro")] LivroDTO livroModel)
        {
            LivroModel model = new LivroModel();
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                model.Nome = livroModel.Nome;
                model.AnoLancamento = livroModel.Ano;
                model.Autor = await _context.AutorModel.FirstOrDefaultAsync(f => f.NomeAutor == livroModel.NomeAutor);
                model.DataCadastro = livroModel.DataCadastro;
                model.AutorId = model.Autor.Id;
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Nome"] = new SelectList(_context.AutorModel, "NomeAutor", "NomeAutor");
            return View(model);
        }

        // GET: Livro/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroModel = await _context.LivroModel.FindAsync(id);
            livroModel.Autor = await _context.AutorModel.FindAsync(livroModel.AutorId);
            var updateModel = new LivroUpdateModel(livroModel.Id, livroModel.Nome, livroModel.AnoLancamento, livroModel.Autor.NomeAutor, livroModel.DataCadastro);
            if (livroModel == null)
            {
                return NotFound();
            }
            ViewData["Nome"] = new SelectList(_context.AutorModel, "NomeAutor", "NomeAutor");
            return View(updateModel);
        }

        // POST: Livro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,Ano,NomeAutor")] LivroUpdateModel livroModel)
        {
            livroModel.Id = id;
            
            if (ModelState.IsValid)
            {
                try
                {
                    var modelBD = new LivroModel();
                    modelBD.Id = id;
                    modelBD.Nome = livroModel.Nome;
                    modelBD.Autor = await _context.AutorModel.FirstOrDefaultAsync(f => f.NomeAutor == livroModel.NomeAutor);
                    modelBD.AnoLancamento = livroModel.Ano;
                    _context.Update(modelBD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroModelExists(livroModel.Id))
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
            ViewData["Nome"] = new SelectList(_context.AutorModel, "NomeAutor", "NomeAutor");
            return View(livroModel);
        }

        // GET: Livro/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroModel = await _context.LivroModel
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livroModel == null)
            {
                return NotFound();
            }

            return View(livroModel);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var livroModel = await _context.LivroModel.FindAsync(id);
            _context.LivroModel.Remove(livroModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroModelExists(Guid id)
        {
            return _context.LivroModel.Any(e => e.Id == id);
        }
    }
}
