using Escola.Models;
using Microsoft.EntityFrameworkCore;

namespace Escola.Contexts
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Turma> Turma { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("Aluno");

            modelBuilder.Entity<Turma>().ToTable("Turma");

            modelBuilder.Entity<Aluno>()
                .HasOne(e => e.Turma) // 1 aluno tem 1 turma
                .WithMany(e => e.Aluno) // 1 turma tem varios alunos
                .HasForeignKey(e => e.Turma_Id); // essa é a FK

            //1 aluno pode ter 1 turma
            //1 turma pode ter varios alunos
        }
    }
}
