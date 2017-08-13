using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejerReact01.Repository
{
    public interface IPersonasRepository
    {
        Persona Create(Persona persona);
        Persona Get(long id);
        IQueryable<Persona> Get();
        void Put(Persona persona);
        Persona Delete(long id);
    }
}
