using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController(){}

        public IActionResult Get ()
        {
            return Ok("Alunos: Marta, Paula, Lucas, Marcia");
        }
        
    }
}