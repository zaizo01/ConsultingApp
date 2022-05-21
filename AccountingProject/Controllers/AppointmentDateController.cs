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
    public class AppointmentDateController : ControllerBase
    {
        private readonly IRepositoryManager repository;
        private readonly IMapper mapper;

        public AppointmentDateController(IRepositoryManager repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentDateById(Guid id)
        {
            var appointmentDate = await repository.AppointmentDate.GetById(id);
            if (appointmentDate == null) return NotFound();
            return Ok(appointmentDate);
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentDate()
        {
            var appointmentDate = await repository.AppointmentDate.GetAll();
            return Ok(appointmentDate);
        }
        [HttpGet]
        public async Task<IActionResult> GetListOfDates(Guid doctorId)
        {
            var dates = await repository.AppointmentDate.GetListOfDates(doctorId);
            return Ok(dates);
        }

        [HttpPost]
        public async Task<IActionResult> PostAppointmentDate(AppointmentDatePostDTO appointmentDateDto)
        {
            if (ModelState.IsValid)
            {
                var validationEntitiesExist = await repository.AppointmentDate.ValidateEntities(appointmentDateDto);
                if (validationEntitiesExist == 1) return new JsonResult("El Doctor no existe");
                if (validationEntitiesExist == 5) return new JsonResult("La fecha de inicio no puede ser igual a la fecha fin");
                if (validationEntitiesExist == 2) return new JsonResult("El Paciente no existe");
                if (validationEntitiesExist == 3) return new JsonResult("El Doctor tiene una cita agendada en esa fecha");
                if (validationEntitiesExist == 5) return new JsonResult("La fecha de inicio no puede ser igual a la fecha fin");
                if (validationEntitiesExist == 6) return new JsonResult("La fecha fin es menor que la fecha de inicio");
                if (validationEntitiesExist == 4)
                {
                    var appointmentDate = mapper.Map<AppointmentDate>(appointmentDateDto);
                    await repository.AppointmentDate.Create(appointmentDate);
                    return Ok(mapper.Map<AppointmentDatePostDTO>(appointmentDate));
                }
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut]
        public async Task<IActionResult> PutAppointmentDate(AppointmentDate appointmentDate)
        {
            var item = await repository.AppointmentDate.Update(appointmentDate);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentDate(Guid id)
        {

            await repository.AppointmentDate.Delete(id);
            return Ok("Record deleted");
        }
    }
}
