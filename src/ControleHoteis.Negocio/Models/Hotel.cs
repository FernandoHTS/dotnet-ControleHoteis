using System;
using System.Collections.Generic;
using System.Text;

namespace ControleHoteis.Negocio.Models
{
    public class Hotel : Entity
    {

        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
        
        public IEnumerable<Quarto> Quartos { get; set; }

    }
}
