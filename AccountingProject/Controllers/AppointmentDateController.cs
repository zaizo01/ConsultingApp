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
    public class AppointmentDateController : ControllerBase
    {
        private readonly IRepositoryManager repository;

        public AppointmentDateController(IRepositoryManager repository)
        {
            this.repository = repository;
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

        [HttpPost]
        public async Task<IActionResult> PostAppointmentDate(AppointmentDate appointmentDate)
        {
            if (ModelState.IsValid)
            {
                await repository.AppointmentDate.Create(appointmentDate);
                return Ok(appointmentDate);
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
