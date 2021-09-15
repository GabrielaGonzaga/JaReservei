using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai_OfertasWebApi.Domains;

#nullable disable

namespace Senai_OfertasWebApi.Contexts
{
    public partial class JaReserveiContext : DbContext
    {
        public JaReserveiContext()
        {
        }

        public JaReserveiContext(DbContextOptions<JaReserveiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pfisica> Pfisicas { get; set; }
        public virtual DbSet<Pjuridica> Pjuridicas { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<TipoProduto> TipoProdutos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
        

        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-RGIIP6F; initial catalog=JaReservei; user Id=sa; pwd=Semprepea10;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Pfisica>(entity =>
            {
                entity.HasKey(e => e.IdPfisica)
                    .HasName("PK__Pfisica__60B4281D71B4F0DA");

                entity.ToTable("Pfisica");

                entity.HasIndex(e => e.Cpf, "UQ__Pfisica__C1F8973112BCFA7D")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone).HasColumnType("decimal(13, 0)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pfisicas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Pfisica__IdUsuar__440B1D61");
            });

            modelBuilder.Entity<Pjuridica>(entity =>
            {
                entity.HasKey(e => e.IdPjuridica)
                    .HasName("PK__Pjuridic__4EE9FF32819F75E3");

                entity.ToTable("Pjuridica");

                entity.HasIndex(e => e.Cnpj, "UQ__Pjuridic__AA57D6B446567394")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.EmailEmpresa)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeEmpresa)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone).HasColumnType("decimal(13, 0)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pjuridicas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Pjuridica__IdUsu__47DBAE45");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__2E883C23C0DE487D");

                entity.ToTable("Produto");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ImagemProduto)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LinkProduto)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.NomeProduto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Preco).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdTipoProdutoNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdTipoProduto)
                    .HasConstraintName("FK__Produto__IdTipoP__403A8C7D");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Produto__IdUsuar__3F466844");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__Reserva__0E49C69D6569255E");

                entity.ToTable("Reserva");

                entity.Property(e => e.PrecoTotal).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Reserva__IdProdu__4AB81AF0");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Reserva__IdUsuar__4BAC3F29");
            });

            modelBuilder.Entity<TipoProduto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProduto)
                    .HasName("PK__TipoProd__F71CDF61F375500E");

                entity.ToTable("TipoProduto");

                entity.Property(e => e.NomeTipoProduto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062BAD5A6C60");

                entity.ToTable("TipoUsuario");

                entity.HasIndex(e => e.TipoUsuario1, "UQ__TipoUsua__52F7E3AA07E6F635")
                    .IsUnique();

                entity.Property(e => e.TipoUsuario1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97FB066BFB");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105341566A4E0")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
