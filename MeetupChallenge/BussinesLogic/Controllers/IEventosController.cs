using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Controllers
{
    public interface IEventosController
    {
        void ObtenerEventos();
        void ObtenerEventosPorUsuario();
        void ObtenerEventosPorFecha();

        void ObtenerEventosPorId();
    }
}
