using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Controllers
{
    public interface IClimaController
    {
        void ObtenerClima(DateTime fecha);

        void ObtenerClimaEvento(int idEvento);


    }
}
