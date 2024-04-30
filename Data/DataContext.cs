using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TarefasApi.Models;
using TarefasApi.Models.Enuns;

namespace TarefasApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Tarefas> TB_TAREFAS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefas>().ToTable("TB_TAREFAS");
            modelBuilder.Entity<Tarefas>().HasData
            (
                new Tarefas() { Id = 1, Nome = "Lavar a Louça", Descrição = "Lavar a louça antes da mãe chegar", Prioridade = Prioridade.Prioridadebaixa, Status = Status.Concluida },
                new Tarefas() { Id = 2, Nome = "Estudar para prova", Descrição = "Estudar c# para proxima prova", Prioridade = Prioridade.PrioridadeAlta, Status = Status.Incompleta },
                new Tarefas() { Id = 3, Nome = "Fazer trabalho escolar", Descrição = "Fazer o trabalho de fisica", Prioridade = Prioridade.Prioridadebaixa, Status = Status.Incompleta },
                new Tarefas() { Id = 4, Nome = "Academia", Descrição = "Ir a academia", Prioridade = Prioridade.Prioridademedia, Status = Status.Concluida },
                new Tarefas() { Id = 5, Nome = "Revisar conteudo passado aula", Descrição = "Revisar conteudo passado na aula de DS", Prioridade = Prioridade.Prioridadebaixa, Status = Status.Concluida }
            );
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(500);
        }
    }
}