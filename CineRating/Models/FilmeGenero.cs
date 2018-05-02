using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class FilmeGenero {

        public FilmeGenero() {
            ListaDeFilmes = new HashSet<Filmes>();
            ListaDeGeneros = new HashSet<Generos>();
        }

        [Key]
        public int ID { get; set; }

        [ForeignKey("ID_Filme")]
        public int MovieFK { get; set; }
        public virtual Filmes ID_Filme { get; set; }


        [ForeignKey("ID_Genero")]
        public int GeneroFK { get; set; }
        public virtual Generos ID_Genero { get; set; }


        public virtual ICollection<Filmes> ListaDeFilmes { get; set; }
        public virtual ICollection<Generos> ListaDeGeneros { get; set; }
    }
}