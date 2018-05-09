using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class Comentario {

        public Comentario() {
        }

        [Key]
        public int ID { get; set; }

        [ForeignKey("ID_User")]
        public int UserFK { get; set; }
        public virtual Utilizadores ID_User { get; set; }


        [ForeignKey("ID_Filme")]
        public int FilmeFK { get; set; }
        public virtual Filmes ID_Filme { get; set; }

        [Display(Name = "Data do Comentário")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime dataComentario { get; set; }

        [Display(Name = "Comentário")]
        public string Texto { get; set; }

    }
}