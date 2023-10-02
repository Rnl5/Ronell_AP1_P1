using Microsoft.EntityFrameworkCore;

namespace Ronell_AP1_P1.DAL;

public class Context : DbContext
{
    public DbSet<Aportes> aportes {get; set;}

    public Context(DbContextOptions<Context> options) : base(options) { }
}