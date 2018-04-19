using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class Diretores {

        public Diretores() {


        }

        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

    }
}