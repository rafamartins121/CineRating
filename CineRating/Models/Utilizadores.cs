using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class Utilizadores {
        public Utilizadores() {
            ListaDeComentarios = new HashSet<Comentario>();
        }

        [Key]
        public int ID { get; set; }

        public string NomeUtilizador { get; set; }

        [RegularExpression("[A-ZÁÂÉÍÓÚ][a-záàâãäèéêëìíîïòóôõöùúûüç]+((-| )((da|de|do|das|dos) )?[A-ZÁÂÉÍÓÚ][a-záàâãäèéêëìíîïòóôõöùúûüç]+)+")]
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        public string Nome { get; set; }

        public virtual ICollection<Comentario> ListaDeComentarios { get; set; }
    }
}