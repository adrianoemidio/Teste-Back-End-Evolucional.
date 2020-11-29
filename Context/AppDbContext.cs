using AppEvolucional.DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AppEvolucional.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AlunoModel> Aluno { get; set;}
        public DbSet<NotasModel> Notas {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Faz o nome de aluno ser unico (UNIQUE)
            modelBuilder.Entity<AlunoModel>()
                .HasIndex(a => new { a.Nome})
                .IsUnique(true);

            //Adiciona no banco de dados um usuários
            const string ADMIN_ID = "87542168-as44-77ss-das-mc4s7lc5297s";
            
            const string ROLE_ID = ADMIN_ID;
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "candidato-evolucional",
                NormalizedName = "candidato-evolucional"
            });

            var hasher = new PasswordHasher<UserModel>();
            modelBuilder.Entity<UserModel>().HasData(new UserModel
            {
                Id = ADMIN_ID,
                UserName = "candidato-evolucional",
                NormalizedUserName = "candidato-evolucional",
                Email = "candidato-evolucional",
                NormalizedEmail = "candidato-evolucional",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456"),
                SecurityStamp = string.Empty
            });
        }
    }


}