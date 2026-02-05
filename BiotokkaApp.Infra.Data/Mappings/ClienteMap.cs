using BiotokkaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>

    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTES");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("ID");                
            
            builder.Property(c => c.NomeCompleto)
               .IsRequired()
               .HasColumnName("NOME_COMPLETO")
               .HasMaxLength(200)
               .HasColumnType("VARCHAR");

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .HasColumnType("VARCHAR");

            builder.Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnName("DATA_NASCIMENTO")
                .HasColumnType("DATE");

            builder.Property(c => c.Endereco)
                .IsRequired()
                .HasColumnName("ENDERECO")
                .HasMaxLength(300)
                .HasColumnType("VARCHAR");

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnName("TELEFONE")
                .HasMaxLength(15)
                .HasColumnType("VARCHAR");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("EMAIL")
                .HasMaxLength(150)
                .HasColumnType("VARCHAR");

            builder.Property(c => c.DataCadastro)
                .IsRequired()
                .HasColumnName("DATA_CADASTRO")
                .HasColumnType("DATETIME");

            // Índices
            builder.HasIndex(c => c.Cpf)
                .IsUnique()
                .HasDatabaseName("IX_Cliente_Cpf");

            builder.HasIndex(c => c.Email)
                .HasDatabaseName("IX_Cliente_Email");

            // Relacionamentos
            builder.HasMany(c => c.Vendas)
                .WithOne(v => v.Cliente)
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
