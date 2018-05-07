using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class Atores {


        public Atores() {
            ListaDePersonagens = new HashSet<Personagem>();
        }

        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Biografia { get; set; }

        public string Imagem { get; set; }


        public virtual ICollection<Personagem> ListaDePersonagens { get; set; }

    }
}