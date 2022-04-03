using ControleHoteis.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoteis.Negocio.Interfaces
{
    public interface IHotelRepository : IRepository<Hotel>
    {

        Task<Hotel> ListarHotelEndereco(Guid id);
        //Task<Hotel> ListarHotelQuartoEndereco(Guid id);

        Task<Hotel> ListarHotelQuartosEndereco(Guid id);

    }
}
