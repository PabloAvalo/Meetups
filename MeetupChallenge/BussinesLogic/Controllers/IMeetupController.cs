using Meetup.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Controllers
{
    public interface IMeetupController
    {
        public  Task<string> ObtenerIdentity();

        public  Task<EventoDto> CrearMeetUpAsync(string nombre, string ciudad, string descripcion, DateTime fecha, int organizadorId, int topicoId);

        public  Task EliminarMeetUp(int eventoId);

        public  Task<double> ObtenerCantidadDeBirras(int eventoId);

        public  Task<ClimaDto> ObtenerClimarDeEvento(int eventoId);

        public  Task<EventoDto> UpdateMeetUp(int eventoId, string ciudad, string descripcion, string nombre, DateTime fecha, int orgId, int topicoId);

        public  Task<EventoDto> ObtenerMeetup(int eventoId);

        public  Task<IEnumerable<EventoDto>> ObtenerOrganizadorMeetups(int organizadorId);

        public Task<IEnumerable<EventoDto>> ObtenerProximosEventos();

        public Task<IEnumerable<EventoDto>> ObtenerEventosPorUsuario(int usuarioId);





    }
}
