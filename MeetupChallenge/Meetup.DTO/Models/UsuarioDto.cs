using BussinesLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.Dto.Models
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

    
        public string Correo { get; set; }
   
        public string Contraseña { get; set; }

        public ICollection<TopicoDto> TopicosDePreferencias { get; set; } = new List<TopicoDto>();

        public bool IsAdmin { get; set; }
    }
}
