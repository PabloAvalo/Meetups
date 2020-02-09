using Meetup.Api.Context;
using Meetup.Api.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Services
{
    public class EventoRepository : IEventoRepository
    {
        private readonly MeetUpContext _context;

        public EventoRepository(MeetUpContext context)
        {
            _context = context;
        }

        public void AddEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            
        }

        public Evento GetEventoById(int id)
        {
            return _context.Eventos.Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<Evento> GetEventos()
        {
            return _context.Eventos.ToList();
        }

        public IEnumerable<Evento> GetEventos(DateTime date)
        {
            return _context.Eventos.Where(e => e.Fecha.Date == date.Date);
        }

        public IEnumerable<Evento> GetEventosByOrganizerId(int organizadorId)
        {
            return _context.Eventos.Where(e => e.OrganizadorId == organizadorId);
        }

        public void Remove(int eventoId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
           return _context.SaveChanges() > 0;
        }

        public void UpdateEvento(Evento evento)
        {
        }


    }
}
