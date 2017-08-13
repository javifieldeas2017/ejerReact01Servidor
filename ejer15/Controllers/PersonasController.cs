
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ejerReact01.Models;
using ejerReact01.Servicios;
using System.Web.Http.Cors;

namespace ejerReact01.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class PersonasController : ApiController
    {
        
        private IPersonasService personasService;

        public PersonasController(IPersonasService _personasService)
        {
            this.personasService = _personasService;
        }

        // GET: api/Personas
        public IQueryable<Persona> GetPersonas()
        {
            return personasService.Get();
        }

        // GET: api/Personas/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult GetPersona(long id)
        {
            Persona persona = personasService.Get(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/Personas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersona(long id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.Id)
            {
                return BadRequest();
            }

            try
            {
                personasService.Put(persona);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Personas
        [ResponseType(typeof(Persona))]
        public IHttpActionResult PostPersona(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            persona = personasService.Create(persona);

            return CreatedAtRoute("DefaultApi", new { id = persona.Id }, persona);
        }

        // DELETE: api/Personas/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult DeletePersona(long id)
        {
            Persona persona;
            try
            {
                persona = personasService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(persona);
        }
    }
}