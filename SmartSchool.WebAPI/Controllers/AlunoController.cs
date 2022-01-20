using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {

        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "Marcos",
                Sobrenome="Almeida",
                Telefone = "12345645"
            },
            new Aluno(){
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Kent",
                Telefone = "34535345"
            },
            new Aluno(){
                Id = 3,
                Nome = "Lucas",
                Sobrenome = "Maria",
                Telefone = "865857567"
            },
        };
        public AlunoController(){}

        [HttpGet]
        public IActionResult Get ()
        {
            return Ok(Alunos);
        }
        //api/aluno/id
        [HttpGet ("{id:int}")]
        public IActionResult GetById(int id){
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) 
                return BadRequest("O aluno não foi encontrado!");

            return Ok(aluno);
        }
        //api/aluno/id
        [HttpGet ("{ByName}")]
        public IActionResult GetByNome(string nome, string Sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a =>a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome));

            if (aluno == null) 
                return BadRequest("O aluno não foi encontrado!");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id,Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
        
    }
}