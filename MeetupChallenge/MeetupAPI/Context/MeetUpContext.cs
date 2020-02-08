using Meetup.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Context
{
    public class MeetUpContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Notificacion> Notificacions { get; set; }
        public DbSet<Topico> Topicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        //Configure options connection string
        public MeetUpContext(DbContextOptions<MeetUpContext> options ) : base(options)
        {
            
        }

        //invites
    }
}
