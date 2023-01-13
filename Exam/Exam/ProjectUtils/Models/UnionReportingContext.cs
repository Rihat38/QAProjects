using Microsoft.EntityFrameworkCore;

namespace Exam.ProjectUtils.Models
{
    public partial class UnionReportingContext : DbContext
    {
        public UnionReportingContext()
        {
        }

        public UnionReportingContext(DbContextOptions<UnionReportingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Login, "author_login_u")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(1000)
                    .HasColumnName("email")
                    .HasComment("Author email");

                entity.Property(e => e.Login)
                    .HasMaxLength(1000)
                    .HasColumnName("login")
                    .HasComment("Author login");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name")
                    .HasComment("Author name");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.TestId, "test_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasComment("Logs of current test");

                entity.Property(e => e.IsException)
                    .HasColumnName("is_exception")
                    .HasComment("Is current log test exception?");

                entity.Property(e => e.TestId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("test_id")
                    .HasComment("Test ID (test.id)");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("log_ibfk_1");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Name, "project_name_u")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name")
                    .HasComment("Project name (1000 symbols)");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("session");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildNumber)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("build_number")
                    .HasComment("Build number");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("Test start time");

                entity.Property(e => e.SessionKey)
                    .HasMaxLength(1000)
                    .HasColumnName("session_key")
                    .HasComment("Session key of current test running");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("Status name (255 symbols)");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.AuthorId, "author_id");

                entity.HasIndex(e => e.ProjectId, "project_id");

                entity.HasIndex(e => e.SessionId, "session_id");

                entity.HasIndex(e => e.StatusId, "status_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AuthorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("author_id")
                    .HasComment("Author info ID (author.id)");

                entity.Property(e => e.Browser)
                    .HasMaxLength(255)
                    .HasColumnName("browser")
                    .HasDefaultValueSql("''")
                    .HasComment("Browser used for tests execution (255 symbols)");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasComment("Test end time");

                entity.Property(e => e.Env)
                    .HasMaxLength(255)
                    .HasColumnName("env")
                    .HasComment("Node name where tests are executed (255 symbols)");

                entity.Property(e => e.MethodName)
                    .HasMaxLength(10000)
                    .HasColumnName("method_name")
                    .HasComment("Test method name (10000 symbols)");

                entity.Property(e => e.Name)
                    .HasMaxLength(10000)
                    .HasColumnName("name")
                    .HasComment("Test name (10000 symbols)");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("project_id")
                    .HasComment("Project ID (project.id)");

                entity.Property(e => e.SessionId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("session_id")
                    .HasComment("ID of current test execution session (session.id)");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("Test start time");

                entity.Property(e => e.StatusId)
                    .HasColumnType("int(1)")
                    .HasColumnName("status_id")
                    .HasComment("Test execution status (status.id)");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("test_ibfk_3");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("test_ibfk_1");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("test_ibfk_2");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("test_ibfk_4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
