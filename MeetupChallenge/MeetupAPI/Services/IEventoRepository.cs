using Meetup.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Services
{
    public interface IEventoRepository
    {
        IEnumerable<Evento> GetEventos();
        IEnumerable<Evento> GetEventos(DateTime date);
        IEnumerable<Evento> GetEventosByOrganizerId(int organizadorId);
        Evento GetEventoById(int id);
        void AddEvento(Evento evento);
        void UpdateEvento(Evento evento);

        void Remove(int eventoId);
        bool Save();
        bool Exists(int id);
        object GetEventosByUserId(int userId);
    }
}
