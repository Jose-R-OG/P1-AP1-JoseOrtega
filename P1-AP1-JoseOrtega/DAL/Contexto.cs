using Microsoft.EntityFrameworkCore;
using P1_AP1_JoseOrtega.Models;

namespace P1_AP1_JoseOrtega.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<EntradasHuacales> EntradasHuacales { get; set; }
}
