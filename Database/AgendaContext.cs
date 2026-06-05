using Microsoft.EntityFrameworkCore;

public class AgendaContext : DbContext
{
    //Tablas
    public DbSet<Contacto> Contactos { get; set; }

    public AgendaContext(DbContextOptions<AgendaContext> options)
        : base(options)
    {
    }
}