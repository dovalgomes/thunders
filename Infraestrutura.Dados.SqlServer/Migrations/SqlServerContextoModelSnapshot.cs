﻿// <auto-generated />
using System;
using Infraestrutura.Dados.SqlServer.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestrutura.Dados.SqlServer.Migrations
{
    [DbContext(typeof(SqlServerContexto))]
    partial class SqlServerContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.Negocio.Entidades.Tarefa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Chave primária (Identificador) de tarefa");

                    b.Property<bool>("Concluida")
                        .HasColumnType("bit")
                        .HasComment("Sinaliza se a tarefa está concluida ou não");

                    b.Property<DateTime?>("DataConclusao")
                        .HasColumnType("datetime2")
                        .HasComment("Data de conclusão da tarefa");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2")
                        .HasComment("Data de criação da tarefa");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Descrição da Tarefa");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Titulo da tarefa");

                    b.HasKey("Id");

                    b.ToTable("Tarefas", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
