using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.BL.Interface;
using SmartSchool.BL.ViewModel;

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        public IClassRoomRepo ClassRoomRepo { get; }
        public ClassRoomController(IClassRoomRepo classRoomRepo)
        {
            ClassRoomRepo = classRoomRepo;

        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            try
            {
                var allClassRooms = ClassRoomRepo.GetAll();
                return Ok(allClassRooms);
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
                var myClassRoom = ClassRoomRepo.GetById(id);
                if (myClassRoom == null)
                {
                    return NotFound();
                }
                return Ok(myClassRoom);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ClassRoomVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = ClassRoomRepo.Create(obj);
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
                ClassRoomRepo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
