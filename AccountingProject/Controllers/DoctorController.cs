
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
    public class DoctorController : ControllerBase
    {
        private readonly IRepositoryManager repository;
        private readonly IMapper mapper;

        public DoctorController(IRepositoryManager repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var doctor = await repository.Doctor.GetById(id);
            if (doctor == null) return NotFound();
            return Ok(mapper.Map<DoctorGetDTO>(doctor));
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorByName(string name)
        {
            var doctor = await repository.Doctor.GetByName(name);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await repository.Doctor.GetAll();
            return Ok(mapper.Map<List<DoctorGetDTO>>(doctors));
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfDates(Guid doctorId)
        {
            var dates = await repository.AppointmentDate.GetListOfDates(doctorId);
            return Ok(mapper.Map<List<ListOfDateByDoctors>>(dates));
        }

        [HttpPost]
        public async Task<IActionResult> PostDoctor(DoctorPostDTO doctorDto)
        {
            if (ModelState.IsValid)
            {
                var doctor = mapper.Map<Doctor>(doctorDto);
                await repository.Doctor.Create(doctor);
                return Ok(mapper.Map<DoctorPostDTO>(doctor));
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut]
        public async Task<IActionResult> PutDoctor(Doctor doctor)
        {
            var doctorDB = await repository.Doctor.Update(doctor);
            return Ok(doctorDB);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {

            await repository.Doctor.Delete(id);
            return Ok("Record deleted");
        }
    }
}
