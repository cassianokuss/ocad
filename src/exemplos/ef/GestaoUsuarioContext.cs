using exemplos.ef.Models;
using Microsoft.EntityFrameworkCore;

namespace exemplos.ef;

public class GestaoUsuarioContext : DbContext
{
    public GestaoUsuarioContext(DbContextOptions<GestaoUsuarioContext> options)
        : base(options)
    { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Perfil> Perfis { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasMany(e => e.Perfis);
            entity.HasOne(e => e.Pessoa);
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
    }
}