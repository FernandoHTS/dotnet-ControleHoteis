using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleHoteis.Aplicacao.ViewModels
{
    public class HotelViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo{0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }


        [DisplayName("CNPJ")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(18, ErrorMessage = "O campo{0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Cnpj { get; set; }


        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo{0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }


        public EnderecoViewModel Endereco { get; set; }

       public IEnumerable<QuartoViewModel> Quartos { get; set; }
       public IEnumerable<FotoViewModel> Fotos { get; set; }




    }
}
