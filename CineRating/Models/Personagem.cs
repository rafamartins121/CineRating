using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class Personagem {

        public Personagem() {
           
        }

        [Key]
        public int ID { get; set; }

        [ForeignKey("ID_Filme")]
        public int MovieFK { get; set; }
        public virtual Filmes ID_Filme { get; set; }

        
        [ForeignKey("ID_Ator")]
        public int AtorFK { get; set; }
        public virtual Atores ID_Ator { get; set; }

        public string Role { get; set; }

        

    }
}