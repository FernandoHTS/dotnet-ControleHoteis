using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleHoteis.Aplicacao.ViewModels
{
    public class QuartoViewModel
    {


        [Key]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Hotel")]
        public Guid HotelId { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo{0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }


        [Required]
        [DisplayName("Qtd. Ocupantes")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Somente números inteiros")]
        public int QtdOcupantes { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Qtd. Adultos")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Somente números inteiros")]
        public int QtdAdultos { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Qtd. Crianças")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Somente números inteiros")]
        public int QtdCriancas { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }


        public HotelViewModel Hotel { get; set; }
        public IEnumerable<HotelViewModel> Hoteis { get; set; }
        public IEnumerable<FotoViewModel> Fotos { get; set; }

    }
}
