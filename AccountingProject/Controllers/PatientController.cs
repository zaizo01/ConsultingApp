using AccountingProject.Contracts;
using AccountingProject.DTOs;
using AccountingProject.Entities;
using AutoMapper;
using LoggerService;
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
        private readonly ILoggerManager logger;

        public PatientController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            try
            {
                var patient = await repository.Patient.GetById(id);
                if (patient is null) return NotFound();
                return Ok(mapper.Map<PatientGetDTO>(patient));
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetPatiens()
        {
            try
            {
                var patiens = await repository.Patient.GetAll();
                return Ok(mapper.Map<List<PatientGetDTO>>(patiens));

            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatiens action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientListDates(Guid patientId)
        {
            try
            {

                var patientDates = await repository.AppointmentDate.GetPatientListOfDates(patientId);
                return Ok(mapper.Map<List<ListOfDatesByPatient>>(patientDates));
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientListDates action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostPatient(PatientPostDTO patientDto)
        {
            try
            {  
                var patient = mapper.Map<Patient>(patientDto);
                await repository.Patient.Create(patient);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the PostPatient action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }           

        }

        [HttpPut]
        public async Task<IActionResult> PutPatient(Patient patient)
        {
            try
            {
                var item = await repository.Patient.Update(patient);
                return Ok(item);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the PutPatient action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            try
            {
                await repository.Patient.Delete(id);
                return Ok("Record deleted");
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the DeletePatient action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
