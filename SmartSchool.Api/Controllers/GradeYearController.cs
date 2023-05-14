using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.BL.Interface;
using SmartSchool.BL.Repository;
using SmartSchool.BL.ViewModel;

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeYearController : ControllerBase
    {
       

        public IGradeYearRepo GradeYearRepo { get; }
        public GradeYearController(IGradeYearRepo gradYearRepo)
        {
            GradeYearRepo = gradYearRepo;
           
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            try
            {
                var allGradeYears = GradeYearRepo.GetAll();
                return Ok(allGradeYears);
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
                var myGradeYear = GradeYearRepo.GetById(id);
                if (myGradeYear == null)
                {
                    return NotFound();
                }
                return Ok(myGradeYear);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public  IActionResult Create(GradeYearVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var data =  GradeYearRepo.Create(obj);
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
                GradeYearRepo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
