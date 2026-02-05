using BiotokkaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Infra.Data.Mappings
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("VENDAS");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                   .HasColumnName("ID");

            builder.Property(v => v.ClienteId)
                   .IsRequired()
                   .HasColumnName("CLIENTE_ID"); 
            builder.Property(v => v.ProdutoId)
                   .IsRequired()
                   .HasColumnName("PRODUTO_ID");
            builder.Property(v => v.Quantidade)
                   .IsRequired()
                   .HasColumnName("QUANTIDADE");
            builder.Property(v => v.PrecoUnitario)
                   .HasColumnType("decimal(10,2)")
                   .IsRequired()
                   .HasColumnName("PRECO_UNITARIO");
            builder.Property(v => v.ValorTotal)
                   .HasColumnType("decimal(10,2)")
                   .IsRequired()
                   .HasColumnName("VALOR_TOTAL");
            builder.Property(v => v.DataVenda)
                   .IsRequired();
            builder.Property(v => v.FormaPagamento)
                   .IsRequired()
                   .HasColumnName("FORMA_PAGAMENTO");
            builder.Property(v => v.Observacoes)
                   .HasMaxLength(500)
                   .HasColumnName("OBSERVACOES")
                   .IsUnicode(false)
                   .IsRequired(false);
            builder.HasOne(v => v.Cliente)
                   .WithMany()
                   .HasForeignKey(v => v.ClienteId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(v => v.Produto)
                   .WithMany()
                   .HasForeignKey(v => v.ProdutoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
