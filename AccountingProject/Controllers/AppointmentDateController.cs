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
    public class AppointmentDateController : ControllerBase
    {
        private readonly IRepositoryManager repository;
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;

        public AppointmentDateController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentDateById(Guid id)
        {
            try
            {
                var appointmentDate = await repository.AppointmentDate.GetById(id);
                if (appointmentDate == null) return NotFound();
                return Ok(appointmentDate);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentDate()
        {
            try
            {
                var appointmentDate = await repository.AppointmentDate.GetAll();
                return Ok(appointmentDate);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAppointmentDate(AppointmentDatePostDTO appointmentDateDto)
        {
            try
            {
                var validationEntitiesExist = await repository.AppointmentDate.ValidateEntities(appointmentDateDto);
                if (validationEntitiesExist == 1) return new JsonResult("El Doctor no existe");
                if (validationEntitiesExist == 5) return new JsonResult("La fecha de inicio no puede ser igual a la fecha fin");
                if (validationEntitiesExist == 2) return new JsonResult("El Paciente no existe");
                if (validationEntitiesExist == 3) return new JsonResult("El Doctor tiene una cita agendada en esa fecha");
                if (validationEntitiesExist == 5) return new JsonResult("La fecha de inicio no puede ser igual a la fecha fin");
                if (validationEntitiesExist == 6) return new JsonResult("La fecha fin es menor que la fecha de inicio");
                else 
                {
                    var appointmentDate = mapper.Map<AppointmentDate>(appointmentDateDto);
                    await repository.AppointmentDate.Create(appointmentDate);
                    return Ok(mapper.Map<AppointmentDatePostDTO>(appointmentDate));
                }

            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAppointmentDate(AppointmentDate appointmentDate)
        {
            try
            {
                var item = await repository.AppointmentDate.Update(appointmentDate);
                return Ok(item);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentDate(Guid id)
        {
            try
            {
                await repository.AppointmentDate.Delete(id);
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
