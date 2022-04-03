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
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {

        public HotelRepository(ControleHoteisContext context) : base(context)
        {

        }

        public async Task<Hotel> ListarHotelEndereco(Guid id)
        {
            return await Db.Hoteis.AsNoTracking()
               .Include(e => e.Endereco)
               .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Hotel> ListarHotelQuartosEndereco(Guid id)
        {
            return await Db.Hoteis.AsNoTracking()
                .Include(h => h.Quartos)
                .Include(h => h.Endereco)
                .FirstOrDefaultAsync(h => h.Id == id);
        }
    }
}
