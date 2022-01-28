using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private SmartContext _context;

        public ProfessorController(SmartContext context){
            _context = context;
        }
        public ProfessorController(){}
        [HttpGet]
        public IActionResult Get ()
        {
            return Ok(_context.Professores);
        }
        [HttpGet {"byid:{id}"]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(a=>a.Id==id);
            if (professor == null) 
                return BadRequest("O aluno não foi encontrado!");

            return Ok(professor);
        }

        [HttpGet ("{ByName}")]
        public IActionResult GetByNome(string nome)
        {
            var professor  = _context.Alunos.AsNoTracking().FirstOrDefault(a =>a.Nome.Contains(nome));
            if (professor == null) 
                return BadRequest("O professor não foi encontrado!");

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post (Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a =>a.Id==id);
            if (alu == null) return BadRequest("Aluno não encontrado!");
                _context.Update(aluno);
            _context.SaveChanges(); 
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id,Professor professor)
        {
            _context.Update(professor);
            _context.SaveChanges(); 
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, Professor professor)
        {
            var alu = _context.Alunos.FirstOrDefault(a =>a.Id==id);
            if (alu == null) return BadRequest("Aluno não encontrado!");
                _context.Remove(professor);
            _context.SaveChanges(); 
            return Ok(professor);
        }
        
    }
}