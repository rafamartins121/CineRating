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

        [Display (Name = "Nome do Realizador")]
        [RegularExpression("[A-ZÁÂÉÍÓÚ][a-záàâãäèéêëìíîïòóôõöùúûüç]+((-| )((da|de|do|das|dos) )?[A-ZÁÂÉÍÓÚ][a-záàâãäèéêëìíîïòóôõöùúûüç]+)+", ErrorMessage = "O {0} está mal escrito.")]
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A {0} é obrigatória!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatória!")]
        public string Biografia { get; set; }

        public string Imagem { get; set; }

        public virtual ICollection<Filmes> ListaDeFilmes { get; set; }

    }
}