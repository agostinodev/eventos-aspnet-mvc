using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Data.Db
{
    public class EventosContext : DbContext
    {
        public EventosContext(DbContextOptions<EventosContext> options) : base(options) 
        { 
        }
        public DbSet<Evento> Eventos => Set<Evento>();
    }
}
