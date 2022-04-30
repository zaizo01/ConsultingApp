using AccountingProject.Contracts;
using AccountingProject.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IRepositoryManager repository;

        public PatientController(IRepositoryManager repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var doctor = await repository.Doctor.GetById(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }


        [HttpGet]
        public async Task<IActionResult> GetPatiens()
        {
            var patiens = await repository.Patient.GetAll();
            return Ok(patiens);
        }

        [HttpPost]
        public async Task<IActionResult> PostPatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                await repository.Patient.Create(patient);
                return Ok(patient);
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut]
        public async Task<IActionResult> PutPatient(Patient patient)
        {
            var item = await repository.Patient.Update(patient);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {

            await repository.Patient.Delete(id);
            return Ok("Record deleted");
        }
    }
}
