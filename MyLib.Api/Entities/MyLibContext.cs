using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyLib.Api.Seeders;

namespace MyLib.Api.Entities
{
    public class MyLibContext : DbContext
    {
        public DbSet<Author> Authors { get; set; } = null!;

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Borrow> Borrows { get; set; } = null!;

        public DbSet<Publisher> Publishers { get; set; } = null!;

        public DbSet<Role> Roles { get; set; } = null!;

        public DbSet<Setting> Settings { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;

        public MyLibContext(DbContextOptions<MyLibContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            modelBuilder.Entity<Author>()
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            modelBuilder.Entity<Author>()
                .Property(p => p.SName)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            modelBuilder.Entity<Book>()
                .Property(p => p.Title)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            modelBuilder.Entity<Book>()
                .Property(p => p.Subtitle)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            modelBuilder.Entity<Book>()
                .Property(p => p.ISBN)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(13);

            modelBuilder.Entity<Book>()
                .Property(p => p.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(p => p.PublisherId)
                .IsRequired();

            modelBuilder.Entity<Borrow>()
                .Property(p => p.BookId)
                .IsRequired();

            modelBuilder.Entity<Borrow>()
                .Property(p => p.LibrarianId)
                .IsRequired();

            modelBuilder.Entity<Borrow>()
                .Property(p => p.BorrowerId)
                .IsRequired();

            modelBuilder.Entity<Borrow>()
                .Property(p => p.CreateDate)
                .IsRequired();

            modelBuilder.Entity<Publisher>()
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            modelBuilder.Entity<Role>()
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(p => p.Login)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20);

            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .IsRequired()
                .HasColumnType("NVARCHAR");

            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(p => p.SName)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(p => p.EMail)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            base.OnModelCreating(modelBuilder);
        }
    }
}
