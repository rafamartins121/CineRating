using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class CineRatingDb : DbContext {

        //construtor da classe

        public CineRatingDb() : base("CineRatingDB") {


        }

        //Identificar as tabelas da base de dados
        public virtual DbSet<Filmes> Filmes { get; set; }
        public virtual DbSet<Atores> Atores { get; set; }
        public virtual DbSet<Generos> Generos { get; set; }
        public virtual DbSet<Utilizadores> Utilizadores { get; set; }
        public virtual DbSet<Diretores> Diretores { get; set; }
        public virtual DbSet<Personagem> Personagem { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }


    }
}
