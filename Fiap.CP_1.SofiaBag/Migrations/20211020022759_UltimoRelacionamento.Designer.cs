﻿// <auto-generated />
using System;
using Fiap.CP_1.SofiaBag.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fiap.CP_1.SofiaBag.Migrations
{
    [DbContext(typeof(MochilaContext))]
    [Migration("20211020022759_UltimoRelacionamento")]
    partial class UltimoRelacionamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiap.CP_1.SofiaBag.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.HasKey("CategoriaId");

                    b.ToTable("TB_CATEGORIA");
                });

            modelBuilder.Entity("Fiap.CP_1.SofiaBag.Models.Lembrete", b =>
                {
                    b.Property<int>("LembreteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DtLembrete")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("LembreteId");

                    b.ToTable("TB_LEMBRETE");
                });

            modelBuilder.Entity("Fiap.CP_1.SofiaBag.Models.ObjetoCategoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("CodigoId")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId", "CodigoId");

                    b.HasIndex("CodigoId");

                    b.ToTable("TB_OBJETOS_CATEGORIAS");
                });

            modelBuilder.Entity("Fiap.CP_1.SofiaBag.Models.Objetos", b =>
                {
                    b.Property<int>("CodigoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LembreteId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("CodigoId");

                    b.HasIndex("LembreteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TB_OBJETOS");
                });

            modelBuilder.Entity("Fiap.CP_1.SofiaBag.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DtNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("NomeCompleto")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeMochila")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId");

                    b.ToTable("T_USUARIO");
                });

            modelBuilder.Entity("Fiap.CP_1.SofiaBag.Models.ObjetoCategoria", b =>
                {
                    b.HasOne("Fiap.CP_1.SofiaBag.Models.Categoria", "Categoria")
                        .WithMany("ObjetosCateg")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.CP_1.SofiaBag.Models.Objetos", "Objeto")
                        .WithMany("ObjetosCateg")
                        .HasForeignKey("CodigoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Objeto");
                });

            modelBuilder.Entity("Fiap.CP_1.SofiaBag.Models.Objetos", b =>
                {
                    b.HasOne("Fiap.CP_1.SofiaBag.Models.Lembrete", "Lembrete")
                        .WithMany()
                        .HasForeignKey("LembreteId");

                    b.HasOne("Fiap.CP_1.SofiaBag.Models.Usuario", "Usuario")
                        .WithMany("Objetos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lembrete");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Fiap.CP_1.SofiaBag.Models.Categoria", b =>
                {
                    b.Navigation("ObjetosCateg");
                });

            modelBuilder.Entity("Fiap.CP_1.SofiaBag.Models.Objetos", b =>
                {
                    b.Navigation("ObjetosCateg");
                });

            modelBuilder.Entity("Fiap.CP_1.SofiaBag.Models.Usuario", b =>
                {
                    b.Navigation("Objetos");
                });
#pragma warning restore 612, 618
        }
    }
}
