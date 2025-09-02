using BetterHealthCare_WebApp.Models.Patients;
using BetterHealthCare_WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetterHealthCare_WebApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly PatientService _service;

        public PatientController(PatientService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await _service.GetAllAsync();
            return View(patients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientDto patient)
        {
            if (!ModelState.IsValid) return View(patient);

            await _service.CreateAsync(patient);
            return RedirectToAction(nameof(Index));
        }

        // Edit, Delete, Details...
    }
}
