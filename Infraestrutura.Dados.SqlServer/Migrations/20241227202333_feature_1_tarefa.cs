using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Dados.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class feature_1_tarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave primária (Identificador) de tarefa"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Titulo da tarefa"),
                    Descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Descrição da Tarefa"),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação da tarefa"),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data de conclusão da tarefa"),
                    Concluida = table.Column<bool>(type: "bit", nullable: false, comment: "Sinaliza se a tarefa está concluida ou não")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
