﻿using System;

namespace ControleHoteis.Negocio.Models
{
    public class Endereco : Entity
    {

        public Guid HotelId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
               
        public Hotel Hotel { get; set; }

    }
}
