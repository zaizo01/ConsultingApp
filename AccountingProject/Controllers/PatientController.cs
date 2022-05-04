using AccountingProject.Contracts;
using AccountingProject.DTOs;
using AccountingProject.Entities;
using AutoMapper;
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
        private readonly IMapper mapper;

        public PatientController(IRepositoryManager repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var patient = await repository.Patient.GetById(id);
            if (patient == null) return NotFound();
            return Ok(mapper.Map<PatientGetDTO>(patient));
        }


        [HttpGet]
        public async Task<IActionResult> GetPatiens()
        {
            var patiens = await repository.Patient.GetAll();
            return Ok(mapper.Map<List<PatientGetDTO>>(patiens));
        }

        [HttpPost]
        public async Task<IActionResult> PostPatient(PatientPostDTO patientDto)
        {
            if (ModelState.IsValid)
            {
                var patient = mapper.Map<Patient>(patientDto);
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
