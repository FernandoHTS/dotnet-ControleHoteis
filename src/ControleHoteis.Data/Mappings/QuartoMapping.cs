using ControleHoteis.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleHoteis.Data.Mappings
{
    public class QuartoMapping : IEntityTypeConfiguration<Quarto>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Quarto> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(q => q.QtdOcupantes)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(q => q.QtdAdultos)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(q => q.QtdCriancas)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(q => q.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");


            builder.ToTable("Quartos");

        }

    }
}
