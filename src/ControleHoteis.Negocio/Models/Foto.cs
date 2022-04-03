using System;
using System.Collections.Generic;
using System.Text;

namespace ControleHoteis.Negocio.Models
{
    public class Foto : Entity
    {

        public Guid ProprietarioFotoId { get; set; }
        public string TipoProprietarioFoto { get; set; }
        public string DescricaoFoto { get; set; }
        public string Imagem { get; set; }

    }
}
