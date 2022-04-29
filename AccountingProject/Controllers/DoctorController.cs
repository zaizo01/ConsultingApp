
using AccountingProject.Entities;
using AccountingProject.Services;
using AccountingProject.Services.Implements;
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

        private GenericRepository<Doctor> repository;

        public DoctorController(GenericRepository<Doctor> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var doctor = await repository.GetById(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await repository.GetAll();
            return Ok(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> PostDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                await repository.Insert(doctor);
                return Ok(doctor);
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut]
        public async Task<IActionResult> PutDoctor(Doctor doctor)
        {
            var item = await repository.Update(doctor);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {

           await repository.Delete(id);
            return Ok("Record deleted");
        }
    }
}
