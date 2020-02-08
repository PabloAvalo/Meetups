using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Controllers
{
    public interface INotificacionController
    {
        void EnviarNotificacion(int userId, string tipoNotificacion, string mensaje);
        void ObtenerNotificacionesDeUsuario(int userId);
        void PrepararNotificaciones(int userId);
    }
}
