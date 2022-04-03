using ControleHoteis.Negocio.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleHoteis.Data.Mappings
{
    public class HotelMapping : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(h => h.Cnpj)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(h => h.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            // 1 : 1 => Hotel : Endereco
            builder.HasOne(h => h.Endereco)
                .WithOne(e => e.Hotel);

            // 1 : N => Hotel : Quarto
            builder.HasMany(h => h.Quartos)
                .WithOne(h => h.Hotel)
                .HasForeignKey(h => h.HotelId);


            builder.ToTable("Hoteis");

        }

    }
}
