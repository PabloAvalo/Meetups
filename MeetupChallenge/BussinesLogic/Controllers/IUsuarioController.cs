using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Controllers
{
    public interface IUsuarioController
    {
        void Login(string usuario, string contraseña);

        void SignUp(string datosUsu);

        void LogOut();

        void CheckIn(int idEvento);

        void InscribirseAEvento(int idEvento);

        void FavearTopico();
        void EliminarTopico();


    }
}
