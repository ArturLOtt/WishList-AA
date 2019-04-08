using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace senai_wishList_desafio_AA.Domains
{
    public partial class WishListContext : DbContext
    {
        public WishListContext()
        {
        }

        public WishListContext(DbContextOptions<WishListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Wish> Wish { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog= senai_wishlist_AA; user id=sa; pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users");

                entity.HasIndex(e => e.UserEmail)
                    .HasName("UQ__users__D54ADF55165C5BB9")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("userEmail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserSenha)
                    .IsRequired()
                    .HasColumnName("userSenha")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wish>(entity =>
            {
                entity.ToTable("wish");

                entity.Property(e => e.WishId).HasColumnName("wishId");

                entity.Property(e => e.WishCreation)
                    .HasColumnName("wishCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.WishDescription)
                    .HasColumnName("wishDescription")
                    .IsUnicode(false);

                entity.Property(e => e.WishOwnerId).HasColumnName("wishOwnerId");

                entity.HasOne(d => d.WishOwner)
                    .WithMany(p => p.Wish)
                    .HasForeignKey(d => d.WishOwnerId)
                    .HasConstraintName("FK__wish__wishOwnerI__571DF1D5");
            });
        }
    }
}
