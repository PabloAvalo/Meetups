using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Meetup.Notificaciones
{
    class Program
    {
        static void Main(string[] args)
        {
           
            DBManager db = new DBManager();

            var notificaciones = NotificacionHandler.GetNotificacionesAEnviar(db);

            foreach (var item in notificaciones)
            {

                NotificacionHandler.Insert("TemplateTitulo", "TemplateMensaje", item.UsuarioId, item.EventoId, db);

            }


        }
    }
}
