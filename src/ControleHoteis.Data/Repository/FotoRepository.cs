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
    public class FotoRepository : Repository<Foto>, IFotoRepository
    {

        public FotoRepository(ControleHoteisContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Foto>> ListarFotosPorProprietarioFoto(Guid proprietarioFotoId, string tipoProprietarioFoto)
        {
            return await Db.Fotos.AsNoTracking().Where(f=>f.ProprietarioFotoId == proprietarioFotoId).Where(f=>f.TipoProprietarioFoto == tipoProprietarioFoto)
                  .ToListAsync();
        }
    }
}
