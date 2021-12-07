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
    public class ReservaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReservaModel.Include(r => r.Livro);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaModel = await _context.ReservaModel
                .Include(r => r.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaModel == null)
            {
                return NotFound();
            }

            return View(reservaModel);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            ViewData["Nome"] = new SelectList(_context.LivroModel, "Nome", "Nome");
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeLocador,NomeLivro,DataCadastro")] ReservaDTO reservaDTO)
        {
            var reservaModel = new ReservaModel();
            if (ModelState.IsValid)
            {
                reservaModel.Id = Guid.NewGuid();
                reservaModel.Livro = await _context.LivroModel.FirstOrDefaultAsync(f => f.Nome == reservaDTO.NomeLivro);
                reservaModel.NomeLocador = reservaDTO.NomeLocador;
                reservaModel.DataCadastro = reservaDTO.DataCadastro;
                _context.Add(reservaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Nome"] = new SelectList(_context.LivroModel, "NomeLivro", "NomeLivro");
            return View(reservaModel);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaModel = await _context.ReservaModel.FindAsync(id);
            reservaModel.Livro = await _context.LivroModel.FindAsync(reservaModel.LivroId);
            var updateModel = new ReservaUpdateModel(reservaModel.Id, reservaModel.NomeLocador,
                reservaModel.DataDevolucao, reservaModel.Livro.Nome, reservaModel.DataCadastro);


            if (reservaModel == null)
            {
                return NotFound();
            }
            ViewData["Nome"] = new SelectList(_context.LivroModel, "Nome", "Nome");
            return View(updateModel);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("NomeLocador,DataDevolucao,NomeLivro")] ReservaUpdateModel reservaModel)
        {
            reservaModel.Id = id;

            if (ModelState.IsValid)
            {
                try
                {
                    var modelBD = new ReservaModel();
                    modelBD.Id = id;
                    modelBD.Livro = await _context.LivroModel.FirstOrDefaultAsync(f => f.Nome == reservaModel.NomeLivro);
                    modelBD.LivroId = modelBD.LivroId;
                    modelBD.DataDevolucao = reservaModel.DataDevolucao;
                    modelBD.NomeLocador = reservaModel.NomeLocador;
                    _context.Update(modelBD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaModelExists(reservaModel.Id))
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
            ViewData["Nome"] = new SelectList(_context.LivroModel, "Nome", "Nome");
            return View(reservaModel);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaModel = await _context.ReservaModel
                .Include(r => r.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaModel == null)
            {
                return NotFound();
            }

            return View(reservaModel);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var reservaModel = await _context.ReservaModel.FindAsync(id);
            _context.ReservaModel.Remove(reservaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaModelExists(Guid id)
        {
            return _context.ReservaModel.Any(e => e.Id == id);
        }
    }
}
