
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
    public class DoctorController : ControllerBase
    {
        private readonly IRepositoryManager repository;
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;

        public DoctorController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            try
            {
                var doctor = await repository.Doctor.GetById(id);
                if (doctor == null) return NotFound();
                return Ok(mapper.Map<DoctorGetDTO>(doctor));
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorByName(string name)
        {
            try
            {
                var doctor = await repository.Doctor.GetByName(name);
                if (doctor == null) return NotFound();
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            try
            {
                var doctors = await repository.Doctor.GetAll();
                return Ok(mapper.Map<List<DoctorGetDTO>>(doctors));
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfDates(Guid doctorId)
        {
            try
            {
                var dates = await repository.AppointmentDate.GetDoctorListOfDates(doctorId);
                return Ok(mapper.Map<List<ListOfDateByDoctors>>(dates));
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostDoctor(DoctorPostDTO doctorDto)
        {
            try
            {
                var doctor = mapper.Map<Doctor>(doctorDto);
                await repository.Doctor.Create(doctor);
                return Ok(mapper.Map<DoctorPostDTO>(doctor));
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutDoctor(Doctor doctor)
        {
            try
            {
                var doctorDB = await repository.Doctor.Update(doctor);
                return Ok(doctorDB);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            try
            {
                await repository.Doctor.Delete(id);
                return Ok("Record deleted");
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
