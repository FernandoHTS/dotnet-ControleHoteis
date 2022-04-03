using ControleHoteis.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleHoteis.Negocio.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {

        Task<Endereco> ListarEnderecoPorHotel(Guid hotelId);

    }
}
