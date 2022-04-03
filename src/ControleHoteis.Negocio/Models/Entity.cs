using System;

namespace ControleHoteis.Negocio.Models
{
    public abstract class Entity
    {

        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid(); 
        }

    }
}
