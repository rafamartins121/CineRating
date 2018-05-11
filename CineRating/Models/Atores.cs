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

        [RegularExpression("[A-ZÁÂÉÍÓÚ][a-záàâãäèéêëìíîïòóôõöùúûüç]+((-| )((da|de|do|das|dos) )?[A-ZÁÂÉÍÓÚ][a-záàâãäèéêëìíîïòóôõöùúûüç]+)+", ErrorMessage = "O {0} está mal escrito.")]
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A {0} é obrigatória!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatória!")]
        public string Biografia { get; set; }

        public string Imagem { get; set; }


        public virtual ICollection<Personagem> ListaDePersonagens { get; set; }

    }
}