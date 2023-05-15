using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.BL.Interface;
using SmartSchool.BL.Repository;
using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Entities;

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        public IScheduleRepo ScheduleRepo { get; }
        public ScheduleController(IScheduleRepo scheduleRepo)
        {
            ScheduleRepo = scheduleRepo;

        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            try
            {
                var allSchedules = ScheduleRepo.GetAll();
                return Ok(allSchedules);
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var mySchedule = ScheduleRepo.GetById(id);
                if (mySchedule == null)
                {
                    return NotFound();
                }
                return Ok(mySchedule);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ScheduleVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = ScheduleRepo.Create(obj);
                    //what to write inside created to redirect to getall page??
                    //try created
                    return Ok(data);
                }
                return BadRequest();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                ScheduleRepo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("Edit")]
        public ActionResult Edit(ScheduleVM obj)
        {

            Schedule s = ScheduleRepo.Edit(obj);
            return Ok(s);
        }
    }
}
