using BetterHealthCare_WebApp.Models;
using BetterHealthCare_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BetterHealthCare_WebApp.Controllers
{
    public class ProcedureController : Controller
    {
        private readonly IProcedureService _procedureService;

        public ProcedureController(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        public async Task<IActionResult> Index()
        {
            var procedures = await _procedureService.GetAllAsync();
            return View(procedures);
        }

        public async Task<IActionResult> Details(int id)
        {
            var procedure = await _procedureService.GetByIdAsync(id);
            if (procedure == null) return NotFound();
            return View(procedure);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(ProcedureDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            await _procedureService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var procedure = await _procedureService.GetByIdAsync(id);
            if (procedure == null) return NotFound();
            return View(procedure);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProcedureDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            await _procedureService.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var procedure = await _procedureService.GetByIdAsync(id);
            if (procedure == null) return NotFound();
            return View(procedure);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _procedureService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
