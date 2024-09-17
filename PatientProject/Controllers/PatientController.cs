using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using ServiceContracts;
using ServiceContracts.Dto;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PatientProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ICountriesService _countriesService;

        public PatientController(IPatientService patientService, ICountriesService countriesService)
        {
            _patientService = patientService;
            _countriesService = countriesService;
        }

        [HttpGet]
        [Route("index")]
        public IActionResult Index(string searchBy, string? searchString,
            string sortBy = nameof(PatientResponse.PatientId), SortOrderOptions sortOrder = SortOrderOptions.ASC)
        {
            List<PatientResponse> patients = _patientService.GetFilteredPatient(searchBy, searchString);
            List<PatientResponse> sortedPatients = _patientService.GetSortedPatients(patients, sortBy, sortOrder);
            return Ok(sortedPatients);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] PatientAddRequest patientAddRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _patientService.AddPatient(patientAddRequest);
            return CreatedAtAction(nameof(Details), new { patientID = " " }, patientAddRequest);
        }

        [HttpGet]
        [Route("edit/{patientId}")]
        public IActionResult Edit(string? patientId)
        {
            PatientResponse? patientResponse = _patientService.GetPatientByPatientId(patientId);
            if (patientResponse == null)
            {
                return NotFound();
            }

            PatientUpdateRequest patientUpdateRequest = patientResponse.ToPatientUpdateRequest();
            return Ok(patientUpdateRequest);
        }

        [HttpPut]
        [Route("edit/{patientId}")]
        public IActionResult Edit([FromBody] PatientUpdateRequest patientUpdateRequest)
        {
            PatientResponse? patientResponse = _patientService.GetPatientByPatientId(patientUpdateRequest.PatientId);
            if (patientResponse == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PatientResponse updatedPatient = _patientService.UpdatePatient(patientUpdateRequest);
            return Ok(updatedPatient);
        }

        [HttpDelete]
        [Route("delete/{patientId}")]
        public IActionResult Delete(string? patientId)
        {
            PatientResponse? patientResponse = _patientService.GetPatientByPatientId(patientId);
            if (patientResponse == null)
            {
                return NotFound();
            }

            _patientService.DeletePatient(patientId);
            return NoContent();
        }

        [HttpGet]
        [Route("PatientsPdf")]
        public async Task<IActionResult> PatientsPdf()
        {
            List<PatientResponse> patients = _patientService.GetAllPatient();
            var pdfContentTask = new ViewAsPdf("PatientsPdf", patients)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins()
                {
                    Top = 20,
                    Right = 20,
                    Bottom = 20,
                    Left = 20
                },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            }.BuildFile(this.ControllerContext);

            var pdfContent = await pdfContentTask;
            return File(pdfContent, "application/pdf", "patients.pdf", true);
        }

        [HttpGet]
        [Route("PatientsExcel")]
        public async Task<IActionResult> PatientsExcel()
        {
            MemoryStream memoryStream = await _patientService.GetPatientsExcel();
            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "patients.xlsx");
        }

        [HttpGet]
        [Route("details/{patientID}")]
        public IActionResult Details(string? patientID)
        {
            PatientResponse? patientResponse = _patientService.GetPatientByPatientId(patientID);
            if (patientResponse == null)
            {
                return NotFound();
            }

            return Ok(patientResponse);
        }
    }
}
