using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai_OfertasWebApi.Domains;

#nullable disable

namespace Senai_OfertasWebApi.Contexts
{
    public partial class SenaiOfertasContext : DbContext
    {
        public SenaiOfertasContext()
        {
        }

        public SenaiOfertasContext(DbContextOptions<SenaiOfertasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pfisica> Pfisicas { get; set; }
        public virtual DbSet<Pjuridica> Pjuridicas { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<TipoProduto> TipoProdutos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0KGDOK7; initial catalog=JaReservei; user Id=sa; pwd=senai@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Pfisica>(entity =>
            {
                entity.HasKey(e => e.IdPfisica)
                    .HasName("PK__Pfisica__60B4281DFFF7E0B2");

                entity.ToTable("Pfisica");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone).HasColumnType("decimal(13, 0)");
            });

            modelBuilder.Entity<Pjuridica>(entity =>
            {
                entity.HasKey(e => e.IdPjuridica)
                    .HasName("PK__Pjuridic__4EE9FF326B65F9AB");

                entity.ToTable("Pjuridica");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

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

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone).HasColumnType("decimal(13, 0)");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__2E883C23F20BA5A9");

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
                    .HasConstraintName("FK__Produto__IdTipoP__3C69FB99");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__Reserva__0E49C69DA924A85D");

                entity.ToTable("Reserva");

                entity.HasOne(d => d.IdPfisicaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdPfisica)
                    .HasConstraintName("FK__Reserva__IdPfisi__403A8C7D");

                entity.HasOne(d => d.IdPjuridicaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdPjuridica)
                    .HasConstraintName("FK__Reserva__IdPjuri__412EB0B6");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Reserva__IdProdu__3F466844");
            });

            modelBuilder.Entity<TipoProduto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProduto)
                    .HasName("PK__TipoProd__F71CDF61BAA2F9C8");

                entity.ToTable("TipoProduto");

                entity.Property(e => e.NomeTipoProduto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
