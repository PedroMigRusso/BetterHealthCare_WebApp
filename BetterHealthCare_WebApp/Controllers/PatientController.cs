using BetterHealthCare_WebApp.Models.Patients;
using BetterHealthCare_WebApp.Services;
using BetterHealthCare_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace BetterHealthCare_WebApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _service;
        private readonly IProcedureService _procedureService;
        private readonly IPatientActionService _patientActionService;

        public PatientController(IPatientService service, IProcedureService procedureService, IPatientActionService patientActionService)
        {
            _service = service;
            _procedureService = procedureService;
            _patientActionService = patientActionService;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await _service.GetAllAsync();
            return View(patients);
        }

        public async Task<IActionResult> Details(int id)
        {
            var patient = await _service.GetWithActionsAsync(id);
            if (patient == null) return NotFound();

            return View(patient);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(PatientDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var created = await _service.CreateAsync(dto);
            if (created) return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Error creating patient.");
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _service.GetByIdAsync(id);
            if (patient == null) return NotFound();
            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PatientDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated) return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Error updating patient.");
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _service.GetByIdAsync(id);
            if (patient == null) return NotFound();
            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (deleted) return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Error deleting patient.");
            return RedirectToAction(nameof(Delete), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> AddAction(int patientId)
        {
            var procedures = await _procedureService.GetAllAsync();

            var vm = new AddPatientActionViewModel
            {
                PatientId = patientId,
                AvailableProcedures = procedures,
                DateOfProcedure = DateTime.Today
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddAction(AddPatientActionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.AvailableProcedures = await _procedureService.GetAllAsync();
                return View(vm);
            }

            var dto = new CreatePatientActionDto
            {
                ProcedureId = vm.SelectedProcedureId,
                DateOfProcedure = vm.DateOfProcedure,
                FilesId = new List<int>()
            };

            await _patientActionService.AddActionAsync(vm.PatientId, dto);

            return RedirectToAction("Details", new { id = vm.PatientId });
        }

    }
}
