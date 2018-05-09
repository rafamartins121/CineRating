using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class Generos {

        public Generos() {
            ListaDeFilmes = new HashSet<Filmes>();
        }

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório!")]
        public string Nome { get; set; }


        public virtual ICollection<Filmes> ListaDeFilmes { get; set; }
    }
}