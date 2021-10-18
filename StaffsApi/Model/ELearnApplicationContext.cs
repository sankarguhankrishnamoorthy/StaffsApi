using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StaffsApi.Model
{
    public partial class ELearnApplicationContext : DbContext
    {
        public ELearnApplicationContext()
        {
        }

        public ELearnApplicationContext(DbContextOptions<ELearnApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseEnroll> CourseEnrolls { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-479\\KSG;Database=ELearnApplication;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId).HasColumnName("Class_id");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Class__Course_id__49C3F6B7");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdateTime).HasColumnType("date");
            });

            modelBuilder.Entity<CourseEnroll>(entity =>
            {
                entity.HasKey(e => e.EnrollId)
                    .HasName("PK__CourseEn__B8F14491A395486F");

                entity.ToTable("CourseEnroll");

                entity.Property(e => e.EnrollId).HasColumnName("Enroll_Id");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseEnrolls)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseEnr__Cours__3B75D760");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseEnrolls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseEnr__UserI__3A81B327");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.Property(e => e.TopicId).HasColumnName("Topic_id");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.Property(e => e.MaterialPath)
                    .HasMaxLength(255)
                    .HasColumnName("Material_path");

                entity.Property(e => e.TopicDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Topic_Desc");

                entity.Property(e => e.TopicName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Topic_Name");

                entity.Property(e => e.VideoPath)
                    .HasMaxLength(255)
                    .HasColumnName("Video_path");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Topics__Course_i__3E52440B");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserAcco__1788CC4CEC7502E3");

                entity.ToTable("UserAccount");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
