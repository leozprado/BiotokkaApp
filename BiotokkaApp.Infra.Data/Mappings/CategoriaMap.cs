using BiotokkaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Infra.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIAS");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("ID");
                   
            builder.Property(c => c.Nome)
               .IsRequired()
               .HasColumnName("NOME")
               .HasMaxLength(100)
               .HasColumnType("VARCHAR");
            builder.Property(c => c.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(500)
                .HasColumnType("VARCHAR");
          
            // Relacionamentos
            builder.HasMany(c => c.Produtos)
                   .WithOne(p => p.Categoria)
                   .HasForeignKey(p => p.CategoriaId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }    
    
}
