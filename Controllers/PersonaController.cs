using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutraAPI.Context;
using OutraAPI.Models;

namespace OutraAPI.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v1/persona")]
    public class PersonaController : ControllerBase
    {
        private readonly APIContext _context;

        public PersonaController(APIContext context)
        {
            _context = context;
        }

        [HttpGet] // Personas com sua lista vazia

        public ActionResult<IEnumerable<Persona>> GetPersonas()
        {
            var personas = _context.Personas.ToList();

            if (personas is null)
            {
                return BadRequest("Nenhuma persona foi encontrada");
            }

            return Ok(personas);
        }

        [HttpGet("dependentes")] // Personas com sua lista populada

        public ActionResult<IEnumerable<Persona>> GetPersonasEDependentes()
        {
            var personas = _context.Personas.Include(x => x.Dependentes).ToList();

            if (personas is null)
            {
                return NotFound("Nenhuma persona foi encontrada");
            }

            return Ok(personas);
        }

        [HttpGet("{id}")] // Personas com sua lista vazia

        public ActionResult<Persona> GetPersonaPorId(int id)
        {
            var persona = _context.Personas.FirstOrDefault(x => x.Id == id);

            if (persona is null)
            {
                return NotFound("Persona não encontrada");
            }

            return Ok(persona);
        }

        [HttpGet("/dependentes/{id}")] // Personas com sua lista populada

        public ActionResult<Persona> GetPersonaPorIdComDependentes(int id)
        {
            var persona = _context.Personas.Include(x => x.Dependentes).FirstOrDefault(y => y.Id == id);

            if (persona is null)
            {
                return NotFound("Persona não encontrada");
            }

            return Ok(persona);
        }

        [HttpPost]
        public ActionResult<Persona> PostPersona(Persona persona)
        {
            if (persona is null)
            {
                return BadRequest("Persona nula");
            }
            _context.Personas.Add(persona);
            _context.SaveChanges();

            return Ok($"Persona de Id: {persona.Id} criada");
        }

        [HttpDelete("id:int")] // Deleta seus dependentes
        public ActionResult<Persona> DeletePersona(int id)
        {
            var persona = _context.Personas.FirstOrDefault(x => x.Id == id);

            if (persona is null)
            {
                return NotFound("Persona não encontrada");
            }

            _context.Personas.Remove(persona);
            _context.SaveChanges();

            return Ok(persona);
        }
    }

}