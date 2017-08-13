using ejerReact01.Models;
using ejerReact01.Servicios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ejerReact01.Repository
{
    public class PersonasRepository : IPersonasRepository
    {
        public Persona Create(Persona persona)
        {


            return ApplicationDbContext.applicationDbContext.Personas.Add(persona);

        }

        public Persona Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.Personas.Find(id);
        }

        public IQueryable<Persona> Get()
        {
            IList<Persona> lista = new List<Persona>(ApplicationDbContext.applicationDbContext.Personas);

            return lista.AsQueryable() ;
        }


        public void Put(Persona persona)
        {
            if (ApplicationDbContext.applicationDbContext.Personas.Count(e => e.Id == persona.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(persona).State = EntityState.Modified;
        }

        public Persona Delete(long id)
        {
            Persona persona = ApplicationDbContext.applicationDbContext.Personas.Find(id);
            if (persona == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Personas.Remove(persona);
            return persona;
       }
    }
}