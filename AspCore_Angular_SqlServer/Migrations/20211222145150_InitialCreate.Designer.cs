﻿// <auto-generated />
using System;
using AspCore_Angular_SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspCore_Angular_SqlServer.Migrations
{
    [DbContext(typeof(ElearningContext))]
    [Migration("20211222145150_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Chapitre", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("MatiereId")
                        .HasColumnName("matiereId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("MatiereId");

                    b.ToTable("chapitre");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<int?>("LessonId")
                        .HasColumnName("lessonId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Eleve", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Image")
                        .HasColumnName("image")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Niveau")
                        .HasColumnName("niveau")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nom")
                        .HasColumnName("nom")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Prenom")
                        .HasColumnName("prenom")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("Tel")
                        .HasColumnName("tel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Eleve");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Enseignant", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Image")
                        .HasColumnName("image")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nom")
                        .HasColumnName("nom")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Prenom")
                        .HasColumnName("prenom")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Specialite")
                        .HasColumnName("specialite")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("Tel")
                        .HasColumnName("tel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Enseignant");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("ChapitreId")
                        .HasColumnName("chapitreId")
                        .HasColumnType("int");

                    b.Property<string>("Descrption")
                        .HasColumnName("descrption")
                        .HasColumnType("text");

                    b.Property<int?>("EnsegnantId")
                        .HasColumnName("ensegnantId")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .HasColumnName("titre")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("ChapitreId");

                    b.HasIndex("EnsegnantId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.LessonEleve", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("EleveId")
                        .HasColumnName("eleveId")
                        .HasColumnType("int");

                    b.Property<int?>("LessonId")
                        .HasColumnName("lessonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EleveId");

                    b.HasIndex("LessonId");

                    b.ToTable("Lesson_Eleve");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Matiere", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("NiveauId")
                        .HasColumnName("niveauId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("NiveauId");

                    b.ToTable("Matiere");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Niveau", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("SectionId")
                        .HasColumnName("sectionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Niveau");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Descrption")
                        .HasColumnName("descrption")
                        .HasColumnType("text");

                    b.Property<int?>("LessonId")
                        .HasColumnName("lessonId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Chapitre", b =>
                {
                    b.HasOne("AspCore_Angular_SqlServer.Models.Matiere", "Matiere")
                        .WithMany("Chapitre")
                        .HasForeignKey("MatiereId")
                        .HasConstraintName("FK_chapitre_ToTable_1");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Document", b =>
                {
                    b.HasOne("AspCore_Angular_SqlServer.Models.Lesson", "Lesson")
                        .WithMany("Document")
                        .HasForeignKey("LessonId")
                        .HasConstraintName("FK_Document_ToTable")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Lesson", b =>
                {
                    b.HasOne("AspCore_Angular_SqlServer.Models.Chapitre", "Chapitre")
                        .WithMany("Lesson")
                        .HasForeignKey("ChapitreId")
                        .HasConstraintName("FK_Lesson_ToTable");

                    b.HasOne("AspCore_Angular_SqlServer.Models.Enseignant", "Ensegnant")
                        .WithMany("Lesson")
                        .HasForeignKey("EnsegnantId")
                        .HasConstraintName("FK_Lesson_ToTable2")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.LessonEleve", b =>
                {
                    b.HasOne("AspCore_Angular_SqlServer.Models.Eleve", "Eleve")
                        .WithMany("LessonEleve")
                        .HasForeignKey("EleveId")
                        .HasConstraintName("FK_Lesson_Eleve_ToTable");

                    b.HasOne("AspCore_Angular_SqlServer.Models.Lesson", "Lesson")
                        .WithMany("LessonEleve")
                        .HasForeignKey("LessonId")
                        .HasConstraintName("FK_Lesson_Eleve_ToTable_1");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Matiere", b =>
                {
                    b.HasOne("AspCore_Angular_SqlServer.Models.Niveau", "Niveau")
                        .WithMany("Matiere")
                        .HasForeignKey("NiveauId")
                        .HasConstraintName("FK_Lesson_ToTable_1");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Niveau", b =>
                {
                    b.HasOne("AspCore_Angular_SqlServer.Models.Section", "Section")
                        .WithMany("Niveau")
                        .HasForeignKey("SectionId")
                        .HasConstraintName("FK_Niveau_ToTable");
                });

            modelBuilder.Entity("AspCore_Angular_SqlServer.Models.Video", b =>
                {
                    b.HasOne("AspCore_Angular_SqlServer.Models.Lesson", "Lesson")
                        .WithMany("Video")
                        .HasForeignKey("LessonId")
                        .HasConstraintName("FK_Video_ToTable")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
