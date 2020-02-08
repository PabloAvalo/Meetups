using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Controllers
{
    public interface IOrganizadorMeetupController
    {
        void CrearMeetUp();

        void UpdateMeetUp();

        void EliminarMeetUp();

        void ObtenerCantidadDeBirras();

        void EnviarInvitaciones();


    }
}
