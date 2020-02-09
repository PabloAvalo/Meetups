using Meetup.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Services
{
    public interface IInscripcionRepository
    {

        void AddInscripcion(Inscripcion inscripcion);

        void Remove(int inscripcionId);

        void Update(int inscripcionId, Inscripcion inscripcion);

        Inscripcion GetInscripcion(int inscripcionId);

        IEnumerable<Inscripcion> GetInscripcioniesDeEvento(int eventoId);

        IEnumerable<Inscripcion> GetInscriptosDeUsuario(int usuarioId);

        bool Save();



    }
}
