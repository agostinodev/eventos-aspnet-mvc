using Microsoft.EntityFrameworkCore;

public class EventosWebContext(DbContextOptions<EventosWebContext> options) : DbContext(options)
{
    public DbSet<Eventos.Web.Models.EventoVM> EventoVM { get; set; } = default!;
}
