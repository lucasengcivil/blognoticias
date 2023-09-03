using NoticiasApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BlogNoticias.Models;

namespace NoticiasApi.Data;

public class NoticiaContext : IdentityDbContext<Editor>
{
    public NoticiaContext(DbContextOptions<NoticiaContext> opts) : base(opts)
    {

    }

    public DbSet<Noticia> Noticias { get; set; }

    public DbSet<Editor> Editors { get; set; }
}
