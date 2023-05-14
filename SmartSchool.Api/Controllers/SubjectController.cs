using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.BL.Interface;
using SmartSchool.BL.ViewModel;

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        public ISubjectRepo SubjectRepo { get; }
        public SubjectController(ISubjectRepo gradYearRepo)
        {
            SubjectRepo = gradYearRepo;

        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            try
            {
                var allSubjects = SubjectRepo.GetAll();
                return Ok(allSubjects);
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
                var mySubject = SubjectRepo.GetById(id);
                if (mySubject == null)
                {
                    return NotFound();
                }
                return Ok(mySubject);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(SubjectVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = SubjectRepo.Create(obj);
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
                SubjectRepo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
