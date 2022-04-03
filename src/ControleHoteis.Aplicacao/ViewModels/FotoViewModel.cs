using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleHoteis.Aplicacao.ViewModels
{
    public class FotoViewModel
    {

        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public Guid ProprietarioFotoId { get; set; }

        [Required]
        public string TipoProprietarioFoto { get; set; }

        [DisplayName("Foto")]
        public IFormFile ImagemUploads { get; set; }
        public string Imagem { get; set; }


        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo{0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string DescricaoFoto { get; set; }      
        

    }
}
