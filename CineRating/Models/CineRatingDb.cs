using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public virtual DbSet<Realizadores> Diretores { get; set; }
        public virtual DbSet<Personagem> Personagem { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }

        /// <summary>
        /// configura a forma como as tabelas são criadas
        /// </summary>
        /// <param name="modelBuilder"> objeto que referencia o gerador de base de dados </param>      
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }



        }
    }
