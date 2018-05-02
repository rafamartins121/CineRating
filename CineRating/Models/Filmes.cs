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
            //ListaDeFilmesGeneros = new HashSet<FilmeGenero>();
            //ListaDeUtilizadores = new HashSet<Utilizadores>();
            //ListaDeDiretores = new HashSet<Diretores>();
            ListaDePersonagens = new HashSet<Personagem>();
            //ListaDeComentarios = new HashSet<Comentario>();

        }

        [Key]
        public int ID { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public int TempoExecucao { get; set; }

        public DateTime DataLancamento { get; set; }

        //FK Diretor
        [ForeignKey("Diretor")]
        public int DiretorFK { get; set; }
        public virtual Diretores Diretor { get; set; }


        //public virtual ICollection<Filmes> ListaDeFilmes { get; set; }
       // public virtual ICollection<FilmeGenero> ListaDeFilmesGeneros{ get; set; }
        //public virtual ICollection<Utilizadores> ListaDeUtilizadores { get; set; }
        //public virtual ICollection<Diretores> ListaDeDiretores { get; set; }
        public virtual ICollection<Personagem> ListaDePersonagens { get; set; }
       //public virtual ICollection<Comentario> ListaDeComentarios { get; set; }
    }
}