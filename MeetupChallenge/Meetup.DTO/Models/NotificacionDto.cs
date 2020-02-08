using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BussinesLogic.Models
{
    public class NotificacionDto
    {

        public int Id { get; set; }
        public string Titulo { get; set; }

      
        public string Mensaje { get; set; }

        public string Link { get; set; }
    }
}
