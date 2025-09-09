using BetterHealthCare_WebApp.Models;
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
        private readonly IMedicalFileService _medicalFileService;

        public PatientController(IPatientService service, IProcedureService procedureService, IPatientActionService patientActionService, IMedicalFileService medicalFileService)
        {
            _service = service;
            _procedureService = procedureService;
            _patientActionService = patientActionService;
            _medicalFileService = medicalFileService;
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

            // 1️⃣ Enviar ficheiros para a API e obter IDs
            var filesId = new List<int>();
            if (vm.UploadedFiles.Any())
            {
                foreach (var file in vm.UploadedFiles)
                {
                    using var ms = new MemoryStream();
                    await file.CopyToAsync(ms);

                    var medicalFileDto = new MedicalFileDto
                    {
                        Base64 = Convert.ToBase64String(ms.ToArray())
                    };

                    var createdFile = await _medicalFileService.UploadFileAsync(medicalFileDto);
                    filesId.Add(createdFile.Id);
                }
            }

            // 2️⃣ Criar PatientAction
            var actionDto = new CreatePatientActionDto
            {
                ProcedureId = vm.SelectedProcedureId,
                DateOfProcedure = vm.DateOfProcedure,
                FilesId = filesId
            };

            await _patientActionService.AddActionAsync(vm.PatientId, actionDto);

            return RedirectToAction("Details", new { id = vm.PatientId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAction(int patientId, int actionId)
        {
            await _patientActionService.DeleteActionAsync(patientId, actionId);
            return RedirectToAction("Details", new { id = patientId });
        }

    }
}
