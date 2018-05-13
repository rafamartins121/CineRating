using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class Filmes {


        public Filmes() {
            //ListaDeFilmes = new HashSet<Filmes>();
            ListaDeGeneros = new HashSet<Generos>();
            //ListaDeUtilizadores = new HashSet<Utilizadores>();
            //ListaDeRealizadores = new HashSet<Realizadores>();
            ListaDePersonagens = new HashSet<Personagem>();
            ListaDeComentarios = new HashSet<Comentario>();

        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A {0} é obrigatória!")]
        public string Descricao { get; set; }

        [Display(Name = "Duração")]
        [Required(ErrorMessage = "A {0} é obrigatória!")]
        public int TempoExecucao { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A {0} é obrigatória!")]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        public string Imagem { get; set; }

        [RegularExpression("^(http(s)?://)?((w){3}.)youtube(.com)(/)embed?/.+", ErrorMessage = "O {0} tem de ter o formato 'www.youtube.com/embed/'id''.")]
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        public string Video { get; set; }


        //FK Diretor
        [ForeignKey("Realizador")]
        public int RealizadorFK { get; set; }
        public virtual Realizadores Realizador { get; set; }


        //public virtual ICollection<Filmes> ListaDeFilmes { get; set; }
        public virtual ICollection<Generos> ListaDeGeneros { get; set; }
        //public virtual ICollection<Utilizadores> ListaDeUtilizadores { get; set; }
        //public virtual ICollection<Realizadores> ListaDeRealizadores { get; set; }
        public virtual ICollection<Personagem> ListaDePersonagens { get; set; }
        public virtual ICollection<Comentario> ListaDeComentarios { get; set; }
    }
}