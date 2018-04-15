using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class Filmes {


        public Filmes() {
            ListaDeFilmes = new HashSet<Filmes>();
            ListaDeGeneros = new HashSet<Generos>();
            ListaDeUtilizadores = new HashSet<Utilizadores>();
            ListaDePessoas = new HashSet<Pessoas>();
        }

        [Key]
        public int ID { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public int TempoExecucao { get; set; }

        public DateTime DataLancamento { get; set; }

        //FK Diretor
        //[ForeignKey("Diretor")]
        //public int DiretorFK { get; set; }
        //public virtual Pessoas Diretor { get; set; }


        public virtual ICollection<Filmes> ListaDeFilmes { get; set; }
        public virtual ICollection<Generos> ListaDeGeneros { get; set; }
        public virtual ICollection<Utilizadores> ListaDeUtilizadores { get; set; }
        public virtual ICollection<Pessoas> ListaDePessoas { get; set; }
    }
}