using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TarefasApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_TAREFAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Descrição = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TAREFAS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_TAREFAS",
                columns: new[] { "Id", "DataCriacao", "Descrição", "Nome", "Prioridade", "Status" },
                values: new object[,]
                {
                    { 1, null, "Lavar a louça antes da mãe chegar", "Lavar a Louça", 3, 1 },
                    { 2, null, "Estudar c# para proxima prova", "Estudar para prova", 1, 2 },
                    { 3, null, "Fazer o trabalho de fisica", "Fazer trabalho escolar", 3, 2 },
                    { 4, null, "Ir a academia", "Academia", 2, 1 },
                    { 5, null, "Revisar conteudo passado na aula de DS", "Revisar conteudo passado aula", 3, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TAREFAS");
        }
    }
}
