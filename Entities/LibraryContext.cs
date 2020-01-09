using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Entities
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookBorrow> BookBorrow { get; set; }
        public virtual DbSet<CityDict> CityDict { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRoleDict> UserRoleDict { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor)
                    .HasName("Author_pk");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.IdBook)
                    .HasName("Book_pk");

                entity.Property(e => e.PublishYear)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Book_Author");

                entity.HasOne(d => d.IdCityDictNavigation)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.IdCityDict)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Book_CityDict");
            });

            modelBuilder.Entity<BookBorrow>(entity =>
            {
                entity.HasKey(e => e.IdBookBorrow)
                    .HasName("BookBorrow_pk");

                entity.Property(e => e.BorrowDate).HasColumnType("datetime");

                entity.Property(e => e.Comments).HasMaxLength(200);

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.BookBorrow)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_6_Book");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.BookBorrow)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_6_User");
            });

            modelBuilder.Entity<CityDict>(entity =>
            {
                entity.HasKey(e => e.IdCityDict)
                    .HasName("CityDict_pk");

                entity.Property(e => e.IdCityDict).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("User_pk");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdUserRoleDictNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdUserRoleDict)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_UserRoleDict");
            });

            modelBuilder.Entity<UserRoleDict>(entity =>
            {
                entity.HasKey(e => e.IdUserRoleDict)
                    .HasName("UserRoleDict_pk");

                entity.Property(e => e.IdUserRoleDict).ValueGeneratedNever();

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
