using Microsoft.EntityFrameworkCore;

namespace WorkingWithDB.Models
{
    public partial class UnionReportingContext : DbContext
    {
        public UnionReportingContext()
        {
        }

        public UnionReportingContext(DbContextOptions<UnionReportingContext>? options)
            : base(options)
        {
        }
        
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Test?> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.HasIndex(e => e.Login)
                    .HasName("author_login_u")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(1000)
                    .HasComment("Author email");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(1000)
                    .HasComment("Author login");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(1000)
                    .HasComment("Author name");
            });
            
            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.HasIndex(e => e.Name)
                    .HasName("project_name_u")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(1000)
                    .HasComment("Project name (1000 symbols)");
            });
            
            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("session");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildNumber)
                    .HasColumnName("build_number")
                    .HasComment("Build number");

                entity.Property(e => e.SessionKey)
                    .IsRequired()
                    .HasColumnName("session_key")
                    .HasMaxLength(1000)
                    .HasComment("Session key of current test running");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .HasComment("Status name (255 symbols)");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.HasIndex(e => e.AuthorId)
                    .HasName("author_id");

                entity.HasIndex(e => e.EndTime)
                    .HasName("end_time");
                
                entity.HasIndex(e => e.StartTime)
                    .HasName("start_time");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id");

                entity.HasIndex(e => e.SessionId)
                    .HasName("session_id");

                entity.HasIndex(e => e.StatusId)
                    .HasName("status_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time");
                
                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasComment("Author info ID (author.id)");

                entity.Property(e => e.Browser)
                    .HasColumnName("browser")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasComment("Browser used for tests execution (255 symbols)");

                entity.Property(e => e.Env)
                    .IsRequired()
                    .HasColumnName("env")
                    .HasMaxLength(255)
                    .HasComment("Node name where tests are executed (255 symbols)");

                entity.Property(e => e.MethodName)
                    .IsRequired()
                    .HasColumnName("method_name")
                    .HasColumnType("varchar(10000)")
                    .HasComment("Test method name (10000 symbols)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(10000)")
                    .HasComment("Test name (10000 symbols)");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasComment("Project ID (project.id)");

                entity.Property(e => e.SessionId)
                    .HasColumnName("session_id")
                    .HasComment("ID of current test execution session (session.id)");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasComment("Test execution status (status.id)");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("test_ibfk_3");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("test_ibfk_1");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("test_ibfk_2");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("test_ibfk_4");
            });
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}