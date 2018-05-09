namespace CineRating.Migrations {
    using CineRating.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CineRating.Models.CineRatingDb> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CineRating.Models.CineRatingDb context) {

            var generos = new List<Generos> {
                new Generos {ID=1, Nome="Ação"},
                new Generos {ID=2, Nome="Aventura" },
                new Generos {ID=3, Nome="Comédia" },
                new Generos {ID=4, Nome="Crime" },
                new Generos {ID=5, Nome="Drama" },
                new Generos {ID=6, Nome="Fantasia" },
                new Generos {ID=7, Nome="Histórico" },
                new Generos {ID=8, Nome="Mistério" },
                new Generos {ID=9, Nome="Romance" },
                new Generos {ID=10, Nome="Terror" },
                new Generos {ID=11, Nome="Ficção Científica"},
                new Generos {ID=12, Nome="Thriller"},
            };
            generos.ForEach(gg => context.Generos.AddOrUpdate(g => g.Nome, gg));
            context.SaveChanges();

            var realizadores = new List<Realizadores> {
                new Realizadores {ID=1, Nome = "Anthony Russo", DataNascimento=new DateTime(1970,2,3), Biografia="", Imagem=""},
                new Realizadores {ID=2, Nome = "Quentin Tarantino", DataNascimento=new DateTime(1963,3,27), Biografia="Quentin Jerome Tarantino é um cineasta, roteirista e ator americano. Alcançou a fama rapidamente no início da década de 1990 por seus roteiros não-lineares, diálogos memoráveis e o uso de violência.", Imagem=""},
                new Realizadores {ID=3, Nome = "Martin Scorsese", DataNascimento=new DateTime(1942,11,17), Biografia="Martin Scorsese é um premiado cineasta, produtor de cinema, roteirista e ator norte-americano. É considerado como um dos maiores diretores de todos os tempos.", Imagem=""},

            };
            realizadores.ForEach(dd => context.Realizadores.AddOrUpdate(d => d.Nome, dd));
            context.SaveChanges();

            var atores = new List<Atores> {
                new Atores {ID=1, Nome = "Chris Pratt", DataNascimento=new DateTime(1979,7,21), Biografia="Christopher Michael Pratt é um ator norte-americano. É conhecido por seus papéis como Harold Brighton Bright Abbott, na série Everwood, como Ché, na quarta temporada de The O.C. e como Andy Dwyer na série de TV americana Parks and Recreation.", Imagem="",},
                new Atores {ID=2, Nome = "Josh Brolin", DataNascimento=new DateTime(1968,2,12), Biografia="Josh James Brolin é um ator americano. Brolin é conhecido principalmente por seus papéis nos filmes The Goonies, No Country for Old Men, Milk, True Grit, Men in Black III e Gangster Squad.", Imagem=""},
                new Atores {ID=3, Nome = "Chris Evans", DataNascimento=new DateTime(1981,6,13), Biografia="Christopher Robert Evans é um ator estadunidense. Ele começou sua carreira na série de televisão Opposite Sex, e desde então apareceu em vários filmes, como Not Another Teen Movie, Sunshine, Scott Pilgrim vs. the World e Snowpiercer.", Imagem=""},
                new Atores {ID=4, Nome = "Chris Hemsworth", DataNascimento=new DateTime(1983,8,11), Biografia="Christopher Hemsworth é um ator australiano. Famoso por interpretar o papel de Kim Hyde na novela Home and Away, se tornou conhecido por seu papel como Thor no Universo Cinematográfico Marvel.", Imagem=""},
                new Atores {ID=5, Nome = "Robert Downey Jr.", DataNascimento=new DateTime(1965,4,4), Biografia="Robert John Downey, Jr. é um premiado ator, cantor, compositor e pianista americano. Estreou como ator em 1970 aos 5 anos, no filme Pound, dirigido por seu pai, Robert Downey, Sr.", Imagem=""},
                new Atores {ID=6, Nome = "Scarlett Johansson", DataNascimento=new DateTime(1984,11,22), Biografia="Scarlett Ingrid Johansson é uma cantora e atriz norte-americana. Ela foi uma das atrizes mais bem pagas de 2014 a 2016, fez múltiplas aparições na Forbes Celebrity 100 e tem uma estrela na Calçada da Fama.", Imagem=""},
                new Atores {ID=7, Nome = "Benedict Cumberbatch", DataNascimento=new DateTime(1976,7,19), Biografia="Benedict Timothy Carlton Cumberbatch é um ator britânico, mais conhecido pelos seus papéis como Sherlock Holmes na série de televisão Sherlock da BBC e como Stephen Strange / Doutor Estranho no Universo Cinematográfico Marvel.", Imagem=""},
                new Atores {ID=8, Nome = "Tom Holland", DataNascimento=new DateTime(1996,6,1), Biografia="Thomas Stanley 'Tom' Holland, é um ator e dançarino britânico, mais conhecido por interpretar Peter Parker / Homem-Aranha no Universo Cinematográfico Marvel. ", Imagem=""},
                new Atores {ID=9, Nome = "Elizabeth Olsen", DataNascimento=new DateTime(1989,2,16), Biografia="Elizabeth Chase Olsen é uma atriz norte-americana conhecida por sua performance no filme Godzilla, e como Feiticeira Escarlate em Vingadores: Era de Ultron, Capitão América: Guerra Civil e Vingadores: Guerra Infinita.", Imagem=""},
                new Atores {ID=10, Nome = "Karen Gillan", DataNascimento=new DateTime(1987,11,28), Biografia="Karen Sheila Gillan é uma atriz e modelo escocesa, mais conhecida por ter interpretado Amy Pond na série britânica de ficção científica exibida pela BBC, Doctor Who.", Imagem=""},
                new Atores {ID=11, Nome = "Zoë Saldaña", DataNascimento=new DateTime(1978,6,19), Biografia="Zoe Yadira Saldaña Nazario é uma atriz estadunidense. Saldana fez sua estréia na tela em um episódio de Law & Order. Sua carreira no cinema começou um ano depois com o filme Center Stage, seguido por Crossroads.", Imagem=""},
                new Atores {ID=12, Nome = "Mark Ruffalo", DataNascimento=new DateTime(1967,11,22), Biografia="Mark Alan Ruffalo é um ator, cineasta, produtor e roteirista norte-americano, mais conhecido pelo papel de Bruce Banner / Hulk no Universo Cinematográfico Marvel, além de outros filmes como You Can Count on Me, Eternal Sunshine of the Spotless Mind, Just Like Heaven, Zodiac, Shutter Island, Now You See Me, Blindness e 13 Going on 30.", Imagem=""},
                new Atores {ID=13, Nome = "Vin Diesel", DataNascimento=new DateTime(1967,7,18), Biografia="Mark Sinclair Vincent, mais conhecido como Vin Diesel é um ator, roteirista e produtor de cinema norte-americano.", Imagem=""},
                new Atores {ID=14, Nome = "Dave Batista", DataNascimento=new DateTime(1969,1,28), Biografia="David Michael 'Dave' Bautista, Jr., é um ator, fisiculturista, lutador de artes marciais mistas e ex-lutador profissional norte-americano, melhor conhecido pela sua passagem na WWE sob o nome Batista.", Imagem=""},
                new Atores {ID=15, Nome = "Paul Bettany", DataNascimento=new DateTime(1971,5,27), Biografia="Paul Bettany é um ator britânico. Iniciou sua carreira no cinema em 1997, mas somente tornou-se conhecido do grande público a partir de suas atuações nos filmes Gangster No. 1 e Coração de Cavaleiro.", Imagem=""},
                new Atores {ID=16, Nome = "Sebastian Stan", DataNascimento=new DateTime(1982,8,13), Biografia="Sebastian Stan é um ator romeno-americano. Aos 12 anos, mudou-se para Rockland County, Nova Iorque, após sua mãe casar-se com o dono de uma escola privada, na qual foi educado. Posteriormente, cursou teatro na Universidade Rutgers, em Nova Jérsei.", Imagem=""},
                new Atores {ID=17, Nome = "Pom Klementieff", DataNascimento=new DateTime(1986,5,3), Biografia="Pom Klementieff é uma atriz franco-canadense, mais conhecida por seu papel no filme de Spike Lee Oldboy.", Imagem=""},
                new Atores {ID=18, Nome = "Tom Hiddleston", DataNascimento=new DateTime(1981,2,9), Biografia="Thomas William Hiddleston, mais conhecido como Tom Hiddleston, é um ator britânico, conhecido pelo seu papel de Loki no [[Universo Cinematográfico Marvel|Universo Cinematográfico da Marvel] Em 2017 venceu o Globo de Ouro de melhor ator em minissérie ou filme para a televisão pelo seu papel na minissérie The Night Manager.", Imagem=""},
                new Atores {ID=19, Nome = "Anthony Mackie", DataNascimento=new DateTime(1978,9,23), Biografia="Anthony Mackie é um ator norte-americano, seus filmes de destaque são A Cor de Um Crime Com Julianne Moore, 8 Mile com Eminem, Capitão América - O Soldado Invernal como Sam Wilson/Falcão, Notorious, filme que ele interpreta o rapper Tupac Shakur e os vencedores do Oscar de melhor filme Menina de Ouro e Guerra ao Terror.", Imagem=""},
                new Atores {ID=20, Nome = "Chadwick Boseman", DataNascimento=new DateTime(1977,11,29), Biografia="Chadwick Aaron Boseman é um ator e roteirista norte-americano. Ele se tornou mais conhecido por seu papel como o herói Pantera Negra nos Estúdios Marvel.", Imagem=""},
                new Atores {ID=21, Nome = "Bradley Cooper", DataNascimento=new DateTime(1975,1,5), Biografia="Bradley Charles Cooper, é um ator e produtor estadunidense mais conhecido pelos seus papéis na trilogia The Hangover.", Imagem=""},



            };
            atores.ForEach(att => context.Atores.AddOrUpdate(at => at.Nome, att));
            context.SaveChanges();



            var filmes = new List<Filmes> {
                new Filmes {ID=1, Titulo = "Os Vingadores", Descricao="Loki, o irmão de Thor, ganha acesso ao poder ilimitado do cubo cósmico ao roubá-lo de dentro das instalações da S.H.I.E.L.D. Nick Fury, o diretor desta agência internacional que mantém a paz, logo reúne os únicos super-heróis que serão capazes de defender a Terra de ameaças sem precedentes. Homem de Ferro, Capitão América, Hulk, Thor, Viúva Negra e Gavião Arqueiro formam o time dos sonhos de Fury, mas eles precisam aprender a colocar os egos de lado e agir como um grupo em prol da humanidade.", TempoExecucao=143, DataLancamento= new DateTime(2012,4,25), Imagem="TheAvengers.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[0], generos[10] }},
                new Filmes {ID=2, Titulo = "Vingadores: A Era de Ultron", Descricao="Ao tentar proteger o planeta de ameaças, Tony Stark constrói um sistema de inteligência artificial que cuidaria da paz mundial. O projeto acaba dando errado e gera o nascimento do Ultron. Com o destino da Terra em jogo, Capitão América, Homem de Ferro, Thor, Hulk, Viúva Negra e Gavião Arqueiro terão que se unir para mais uma vez salvar a raça humana da extinção.", TempoExecucao=144, DataLancamento= new DateTime(2015,4,29), Imagem="AvengersAgeOfUltron.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[0], generos[10] }},
                new Filmes {ID=3, Titulo = "Vingadores: Guerra do Infinito", Descricao="Homem de Ferro, Thor, Hulk e os Vingadores se unem para combater seu inimigo mais poderoso, o maligno Thanos. Em uma missão para coletar todas as seis pedras infinitas, Thanos planeja usá-las para infligir sua vontade maléfica sobre a realidade.", TempoExecucao=160, DataLancamento= new DateTime(2018,4,23), Imagem="AvengersInfinityWar.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[0], generos[10] } },
                new Filmes {ID=4, Titulo = "Capitão América: O Soldado do Inverno", Descricao="Após os eventos catastróficos em Nova York com Os Vingadores, Steve Rogers, também conhecido como Capitão América, segue tentando se ajustar ao mundo moderno. Porém, quando um colega da agência S.H.I.E.L.D. é atacado, Steve se vê preso em uma rede de intrigas que ameaça colocar o mundo em risco. Em parceria com a Viúva Negra e Falcão, seu novo aliado, o Capitão América tem que enfrentar um misterioso e inesperado inimigo, o Soldado Invernal.", TempoExecucao=136, DataLancamento= new DateTime(2015,3,27), Imagem="CaptainAmericaWinterSoldier.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[0], generos[11] }},
            };
            filmes.ForEach(ff => context.Filmes.AddOrUpdate(f => f.Titulo, ff));
            context.SaveChanges();

            var personagem = new List<Personagem> {
                //The Avengers
                 new Personagem { ID=1, MovieFK=1, AtorFK=5, Role="Iron Man" },
                 new Personagem { ID=2, MovieFK=1, AtorFK=3, Role="Captain America" },
                 new Personagem { ID=3, MovieFK=1, AtorFK=6, Role="Black Widow" },
                 new Personagem { ID=4, MovieFK=1, AtorFK=9, Role="Scarlet Witch" },
                 new Personagem { ID=5, MovieFK=1, AtorFK=12, Role="Hulk" },
                 new Personagem { ID=6, MovieFK=1, AtorFK=4, Role="Thor" },
                 new Personagem { ID=7, MovieFK=1, AtorFK=15, Role="Vision" },
                 new Personagem { ID=8, MovieFK=1, AtorFK=19, Role="Falcon" },
                 new Personagem { ID=9, MovieFK=1, AtorFK=18, Role="Loki" },

                 //avengers age of ultron
                 new Personagem { ID=10, MovieFK=2, AtorFK=5, Role="Iron Man" },
                 new Personagem { ID=11, MovieFK=2, AtorFK=3, Role="Captain America" },
                 new Personagem { ID=12, MovieFK=2, AtorFK=6, Role="Black Widow" },
                 new Personagem { ID=13, MovieFK=2, AtorFK=9, Role="Scarlet Witch" },
                 new Personagem { ID=14, MovieFK=2, AtorFK=12, Role="Hulk" },
                 new Personagem { ID=15, MovieFK=2, AtorFK=4, Role="Thor" },
                 new Personagem { ID=16, MovieFK=2, AtorFK=15, Role="Vision" },
                 new Personagem { ID=17, MovieFK=2, AtorFK=19, Role="Falcon" },
                 new Personagem { ID=18, MovieFK=2, AtorFK=18, Role="Loki" },

                 //Avengers Infinity War
                 new Personagem { ID=19, MovieFK=3, AtorFK=1, Role="Star Lord" },
                 new Personagem { ID=20, MovieFK=3, AtorFK=2, Role="Thanos" },
                 new Personagem { ID=21, MovieFK=3, AtorFK=3, Role="Captain America" },
                 new Personagem { ID=22, MovieFK=3, AtorFK=4, Role="Thor" },
                 new Personagem { ID=23, MovieFK=3, AtorFK=5, Role="Iron Man" },
                 new Personagem { ID=24, MovieFK=3, AtorFK=6, Role="Black Widow" },
                 new Personagem { ID=25, MovieFK=3, AtorFK=7, Role="Doctor Strange" },
                 new Personagem { ID=26, MovieFK=3, AtorFK=8, Role="Spider-Man" },
                 new Personagem { ID=27, MovieFK=3, AtorFK=9, Role="Scarlet Witch" },
                 new Personagem { ID=28, MovieFK=3, AtorFK=10, Role="Nebula" },
                 new Personagem { ID=29, MovieFK=3, AtorFK=11, Role="Gamora" },
                 new Personagem { ID=30, MovieFK=3, AtorFK=12, Role="Hulk" },
                 new Personagem { ID=31, MovieFK=3, AtorFK=13, Role="Groot" },
                 new Personagem { ID=32, MovieFK=3, AtorFK=14, Role="Drax" },
                 new Personagem { ID=33, MovieFK=3, AtorFK=15, Role="Vision" },
                 new Personagem { ID=34, MovieFK=3, AtorFK=16, Role="Bucky" },
                 new Personagem { ID=35, MovieFK=3, AtorFK=17, Role="Mantis" },
                 new Personagem { ID=36, MovieFK=3, AtorFK=18, Role="Loki" },
                 new Personagem { ID=37, MovieFK=3, AtorFK=19, Role="Falcon" },
                 new Personagem { ID=38, MovieFK=3, AtorFK=20, Role="Black Panther" },
                 new Personagem { ID=39, MovieFK=3, AtorFK=21, Role="Rocket Racoon" },

                 //Captain America
                 new Personagem { ID=40, MovieFK=4, AtorFK=3, Role="Captain America" },
                 new Personagem { ID=41, MovieFK=4, AtorFK=6, Role="Black Widow" },
                 new Personagem { ID=42, MovieFK=4, AtorFK=16, Role="Bucky" },
                 new Personagem { ID=43, MovieFK=4, AtorFK=19, Role="Falcon" },

             };
            personagem.ForEach(pp => context.Personagem.AddOrUpdate(p => p.MovieFK, pp));
            context.SaveChanges();

            var utilizadores = new List<Utilizadores> {
                 new Utilizadores { ID=1, NomeUtilizador="Joao@mail.com", Nome="Joao"  },
                 new Utilizadores { ID=2, NomeUtilizador="Carlos@mail.com", Nome="Carlos"  },
                 new Utilizadores { ID=3, NomeUtilizador="José@mail.com", Nome="José"  },
                 new Utilizadores { ID=4, NomeUtilizador="Rafael@mail.com", Nome="Rafael"  },
                 new Utilizadores { ID=5, NomeUtilizador="Sara@mail.com", Nome="Sara"  },
                 new Utilizadores { ID=6, NomeUtilizador="Joana@mail.com", Nome="Joana"  },
                 new Utilizadores { ID=7, NomeUtilizador="Raquel@mail.com", Nome="Raquel"  },
             };
            utilizadores.ForEach(uu => context.Utilizadores.AddOrUpdate(u => u.NomeUtilizador, uu));
            context.SaveChanges();

            var comentarios = new List<Comentario> {
                 new Comentario { ID=1, FilmeFK =1, UserFK=1, dataComentario = new DateTime(2018,5,9), Texto="Fixe"   },
                 new Comentario { ID=2, FilmeFK =3, UserFK=2, dataComentario = new DateTime(2018,5,4), Texto="Fixe"   },
                 new Comentario { ID=3, FilmeFK =2, UserFK=3, dataComentario = new DateTime(2018,5,2),  Texto="Fixe"   },
                 new Comentario { ID=4, FilmeFK =1, UserFK=4, dataComentario = new DateTime(2018,5,3), Texto="Fixe"   },
                 new Comentario { ID=5, FilmeFK =1, UserFK=5, dataComentario = new DateTime(2018,4,2), Texto="Fixe"   },
                 new Comentario { ID=6, FilmeFK =2, UserFK=6, dataComentario = new DateTime(2018,3,23), Texto="Fixe"   },
                 new Comentario { ID=7, FilmeFK =3, UserFK=7, dataComentario = new DateTime(2018,5,1), Texto="Fixe"   },
             };
            comentarios.ForEach(cc => context.Comentario.AddOrUpdate(c => c.FilmeFK, cc));
            context.SaveChanges();



        }
    }
}