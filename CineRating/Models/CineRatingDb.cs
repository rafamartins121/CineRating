using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CineRating.Models {
    public class CineRatingDb : DbContext {

        //construtor da classe

        public CineRatingDb() : base("CineRatingDBConnectionString") {


        }

        //Identificar as tabelas da base de dados
        public virtual DbSet<Filmes> Filmes { get; set; }
        public virtual DbSet<Pessoas> Pessoas { get; set; }
        public virtual DbSet<Generos> Generos { get; set; }
        public virtual DbSet<Utilizadores> Utilizadores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }


    }
}
