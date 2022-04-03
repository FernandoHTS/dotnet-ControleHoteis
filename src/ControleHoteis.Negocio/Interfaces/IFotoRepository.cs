using ControleHoteis.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleHoteis.Negocio.Interfaces
{
    public interface IFotoRepository : IRepository<Foto>
    {

        Task<IEnumerable<Foto>> ListarFotosPorProprietarioFoto(Guid proprietarioFotoId, string tipoProprietarioFoto);

    }
}
