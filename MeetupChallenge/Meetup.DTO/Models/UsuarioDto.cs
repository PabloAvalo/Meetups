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

        public IEnumerable<ConfiguracionDto> Configuracion { get; set; } = new List <ConfiguracionDto>();

        public bool IsAdmin { get; set; }
    }
}
