using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AspCore_Angular_SqlServer.Models
{
    public partial class ElearningContext : DbContext
    {
        public ElearningContext()
        {
        }

        public ElearningContext(DbContextOptions<ElearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chapitre> Chapitre { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Eleve> Eleve { get; set; }
        public virtual DbSet<Enseignant> Enseignant { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<LessonEleve> LessonEleve { get; set; }
        public virtual DbSet<Matiere> Matiere { get; set; }
        public virtual DbSet<Niveau> Niveau { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Video> Video { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-U01KBHR\\SQLEXPRESS;Initial Catalog=Elearning;Integrated Security=True;Pooling=False");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chapitre>(entity =>
            {
                entity.ToTable("chapitre");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MatiereId).HasColumnName("matiereId");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.HasOne(d => d.Matiere)
                    .WithMany(p => p.Chapitre)
                    .HasForeignKey(d => d.MatiereId)
                    .HasConstraintName("FK_chapitre_ToTable_1");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.LessonId).HasColumnName("lessonId");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("text");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Document_ToTable");
            });

            modelBuilder.Entity<Eleve>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Niveau)
                    .HasColumnName("niveau")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tel).HasColumnName("tel");
            });

            modelBuilder.Entity<Enseignant>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Specialite)
                    .HasColumnName("specialite")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Tel).HasColumnName("tel");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChapitreId).HasColumnName("chapitreId");

                entity.Property(e => e.Descrption)
                    .HasColumnName("descrption")
                    .HasColumnType("text");

                entity.Property(e => e.EnsegnantId).HasColumnName("ensegnantId");

                entity.Property(e => e.Titre)
                    .HasColumnName("titre")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Chapitre)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.ChapitreId)
                    .HasConstraintName("FK_Lesson_ToTable");

                entity.HasOne(d => d.Ensegnant)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.EnsegnantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Lesson_ToTable2");
            });

            modelBuilder.Entity<LessonEleve>(entity =>
            {
                entity.ToTable("Lesson_Eleve");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EleveId).HasColumnName("eleveId");

                entity.Property(e => e.LessonId).HasColumnName("lessonId");

                entity.HasOne(d => d.Eleve)
                    .WithMany(p => p.LessonEleve)
                    .HasForeignKey(d => d.EleveId)
                    .HasConstraintName("FK_Lesson_Eleve_ToTable");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.LessonEleve)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK_Lesson_Eleve_ToTable_1");
            });

            modelBuilder.Entity<Matiere>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NiveauId).HasColumnName("niveauId");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.HasOne(d => d.Niveau)
                    .WithMany(p => p.Matiere)
                    .HasForeignKey(d => d.NiveauId)
                    .HasConstraintName("FK_Lesson_ToTable_1");
            });

            modelBuilder.Entity<Niveau>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SectionId).HasColumnName("sectionId");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Niveau)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_Niveau_ToTable");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descrption)
                    .HasColumnName("descrption")
                    .HasColumnType("text");

                entity.Property(e => e.LessonId).HasColumnName("lessonId");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("text");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Video)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Video_ToTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
