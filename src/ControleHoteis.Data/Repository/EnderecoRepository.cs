using ControleHoteis.Data.Context;
using ControleHoteis.Negocio.Interfaces;
using ControleHoteis.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoteis.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {

        public EnderecoRepository(ControleHoteisContext context) : base(context)
        {

        }

        public async Task<Endereco> ListarEnderecoPorHotel(Guid hotelId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(h => h.HotelId == hotelId);
        }

    }
}
