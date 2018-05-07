using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class Realizadores {

        public Realizadores() {

            ListaDeFilmes = new HashSet<Filmes>();

        }

        [Key]
        public int ID { get; set; }

        [Display (Name = "Diretor")]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Biografia { get; set; }

        public string Imagem { get; set; }

        public virtual ICollection<Filmes> ListaDeFilmes { get; set; }

    }
}