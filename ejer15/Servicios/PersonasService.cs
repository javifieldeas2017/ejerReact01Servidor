using ejerReact01.Models;
using ejerReact01.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace ejerReact01.Servicios
{
    public class PersonasService : IPersonasService
    {
        private IPersonasRepository personasRepository;
        public PersonasService(IPersonasRepository _personasRepository)
        {
            this.personasRepository = _personasRepository;
        }

        public Persona Get(long id)
        {
               return personasRepository.Get(id);
        }

        public IQueryable<Persona> Get()
        {
            return personasRepository.Get();
        }

        public Persona Create(Persona persona)
        {
              return personasRepository.Create(persona);
        }

        public void Put(Persona persona)
        {
              personasRepository.Put(persona);
        }

        public Persona Delete(long id)
        {
            return personasRepository.Delete(id);
        }
    }
}