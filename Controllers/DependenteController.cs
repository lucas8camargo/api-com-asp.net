using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutraAPI.Context;
using OutraAPI.Models;

namespace OutraAPI.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v1/dependente")]
    public class DependenteController : ControllerBase
    {
        private readonly APIContext _context;

        public DependenteController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Persona>> GetDependentes()
        {
            var dependente = _context.Dependentes.ToList();

            if (dependente is null)
            {
                return NotFound("Nenhum Dependente foi encontrado");
            }

            return Ok(dependente);
        }

        [HttpGet("{id}")]

        public ActionResult<Persona> GetDependentePorId(int id)
        {
            var dependente = _context.Dependentes.FirstOrDefault(x => x.Id == id);

            if (dependente is null)
            {
                return NotFound("Dependente não encontrado");
            }

            return Ok(dependente);
        }

        [HttpPost]
        public ActionResult<Dependente> PostDependente(Dependente dependente)
        {
            if (dependente is null)
            {
                return BadRequest("Dependente nulo");
            }
            _context.Dependentes.Add(dependente);
            _context.SaveChanges();

            return Ok($"Dependente de Id: {dependente.Id} criado");
        }

        [HttpDelete("id:int")]
        public ActionResult<Dependente> DeleteDependente(int id)
        {
            var dependente = _context.Dependentes.FirstOrDefault(x => x.Id == id);

            if (dependente is null)
            {
                return NotFound("Dependente não encontrado");
            }

            _context.Dependentes.Remove(dependente);
            _context.SaveChanges();

            return Ok(dependente);
        }

    }
}