using BiotokkaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTOS");

            builder.HasKey(p => p.Id);

            builder.Property(m => m.Id).HasColumnName("ID");
            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Custo)
                .HasColumnName("CUSTO")
                .IsRequired()
                .HasColumnType("decimal(10,2)");
            builder.Property(p => p.PrecoVenda)
                .HasColumnName("PRECO_VENDA")       
                .IsRequired()
                .HasColumnType("decimal(10,2)");
            builder.Property(p => p.DataCadastro)
                .HasColumnName("DATA_CADASTRO")
                .IsRequired();
            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
