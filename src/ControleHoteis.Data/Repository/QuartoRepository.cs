using ControleHoteis.Data.Context;
using ControleHoteis.Negocio.Interfaces;
using ControleHoteis.Negocio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoteis.Data.Repository
{
    public class QuartoRepository : Repository<Quarto>, IQuartoRepository
    {

        public QuartoRepository(ControleHoteisContext context) : base(context)
        {

        }

        public async Task<Quarto> ListarQuartoHotel(Guid id)
        {
            return await Db.Quartos.AsNoTracking().Include(h => h.Hotel)
                 .FirstOrDefaultAsync(predicate => predicate.Id == id);
        }

        public async Task<IEnumerable<Quarto>> ListarQuartosHoteis()
        {
            return await Db.Quartos.AsNoTracking().Include(h => h.Hotel)
                 .OrderBy(q => q.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Quarto>> ListarQuartosPorHotel(Guid hotelId)
        {
            return await Buscar(q => q.HotelId == hotelId);
        }
    }
}
