using Microsoft.EntityFrameworkCore;
using P2_AP1_RonnelDeLaCruz.Models;

namespace P2_AP1_RonnelDeLaCruz.DAL;

public class Contexto : DbContext
{
    public DbSet<Registros> Registros { get; set; }
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
}