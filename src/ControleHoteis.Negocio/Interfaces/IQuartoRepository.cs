using ControleHoteis.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoteis.Negocio.Interfaces
{
    public interface IQuartoRepository : IRepository<Quarto>
    {

        Task<IEnumerable<Quarto>> ListarQuartosPorHotel(Guid hotelId);
        Task<IEnumerable<Quarto>> ListarQuartosHoteis();

        Task<Quarto> ListarQuartoHotel(Guid id);

    }
}
