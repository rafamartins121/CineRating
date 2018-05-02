using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class Comentario {

        public Comentario() {
            ListaDeFilmes = new HashSet<Filmes>();
        }

        [Key]
        public int ID { get; set; }

        [ForeignKey("ID_User")]
        public int UserFK { get; set; }
        public virtual Filmes ID_User { get; set; }


        [ForeignKey("ID_Filme")]
        public int FilmeFK { get; set; }
        public virtual Atores ID_Filme { get; set; }

        public string Texto { get; set; }

        public virtual ICollection<Filmes> ListaDeFilmes { get; set; }

    }
}