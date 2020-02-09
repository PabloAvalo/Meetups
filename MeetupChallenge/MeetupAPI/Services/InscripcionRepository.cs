using Meetup.Api.Context;
using Meetup.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Services
{
    public class InscripcionRepository : IInscripcionRepository
    {
        private readonly MeetUpContext _context;

        public InscripcionRepository(MeetUpContext context)
        {
            _context = context;
        }

    
        public IEnumerable<Inscripcion> GetInscripcioniesDeEvento(int eventoId)
        {
            return _context.Inscripciones.Where(i => i.EventoId == eventoId);
        }

        public IEnumerable<Inscripcion> GetInscriptosDeUsuario(int usuarioId)
        {
            return _context.Inscripciones.Where(i => i.UsuarioId == usuarioId);
        }

        public void AddInscripcion(Inscripcion inscripcion)
        {
            _context.Inscripciones.Add(inscripcion);
        }

        public void Remove(int inscripcionId)
        {

            var inscripcion = _context.Inscripciones.Find(inscripcionId);
            if (inscripcion == null) return;
            _context.Inscripciones.Remove(inscripcion);
            
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update(int inscripcionId, Inscripcion inscripcion)
        {
            
        }

        public Inscripcion GetInscripcion(int inscripcionId)
        {
            return _context.Inscripciones.Find(inscripcionId);
        }
    }
}
