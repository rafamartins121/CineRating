using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class Utilizadores {

        public Utilizadores() {
            ListaDeFilmes = new HashSet<Filmes>();
        }

        [Key]
        public int ID { get; set; }

        public string NomeUtilizador { get; set; }

        public string password { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Filmes> ListaDeFilmes { get; set; }
    }
}