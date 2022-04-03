using System;
using System.Collections.Generic;
using System.Text;

namespace ControleHoteis.Negocio.Models
{
    public class Quarto : Entity
    {

        public Guid HotelId { get; set; }
        public string Nome { get; set; }
        public int QtdOcupantes { get; set; }
        public int QtdAdultos { get; set; }
        public int QtdCriancas { get; set; }
        public decimal Valor { get; set; }

        public Hotel Hotel { get; set; }       

    }
}
