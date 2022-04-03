using ControleHoteis.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleHoteis.Data.Mappings
{
    public class FotoMapping : IEntityTypeConfiguration<Foto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Foto> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Imagem)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(f => f.TipoProprietarioFoto)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.DescricaoFoto)
                .IsRequired()
                .HasColumnType("varchar(200)");



            builder.ToTable("Fotos");

        }

    }
}
