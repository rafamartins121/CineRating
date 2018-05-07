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
            };
            atores.ForEach(att => context.Atores.AddOrUpdate(at => at.Nome, att));
            context.SaveChanges();

            var filmes = new List<Filmes> {
                new Filmes {ID=1, Titulo = "Vingadores: Guerra do Infinito", Descricao="Homem de Ferro, Thor, Hulk e os Vingadores se unem para combater seu inimigo mais poderoso, o maligno Thanos. Em uma missão para coletar todas as seis pedras infinitas, Thanos planeja usá-las para infligir sua vontade maléfica sobre a realidade.", TempoExecucao=160, DataLancamento= new DateTime(2018,4,23), Imagem="TheAvengers.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[0], generos[1] } },
                new Filmes {ID=2, Titulo = "Um Lugar Silencioso", Descricao="Em uma fazenda nos Estados Unidos, uma família do Meio-Oeste é perseguida por uma entidade fantasmagórica assustadora. Para se protegerem, eles devem permanecer em silêncio absoluto, a qualquer custo, pois o perigo é ativado pela percepção do som.", TempoExecucao=95, DataLancamento= new DateTime(2018,4,3), Imagem="AQuietPlace.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[1], generos[2] }},
                new Filmes {ID=3, Titulo = "Beirut", Descricao="Beirut é um filme de drama estadunidense de 2018 dirigido e escrito por Brad Anderson e Tony Gilroy. Estrelado por Jon Hamm, Rosamund Pike, Dean Norris e Shea Whigham, estreou no Festival Sundance de Cinema em 22 de janeiro de 2018.", TempoExecucao=109, DataLancamento= new DateTime(2018,4,11), Imagem="Beirut.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[2], generos[5] }},
                new Filmes {ID=4, Titulo = "Rampage: Fora de Controle", Descricao="Davis Okoye é um primatologista, um homem recluso que compartilha um vínculo inabalável com George, um gorila muito inteligente que está sob seus cuidados desde o nascimento.", TempoExecucao=115, DataLancamento= new DateTime(2018,4,12), Imagem="Rampage.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[5], generos[3] }},
                new Filmes {ID=5, Titulo = "Desejo de Matar", Descricao="Após ter sua casa invadida e esposa assassinada por bandidos, Paul passa a acompanhar a polícia nas investigações para capturar os criminosos.", TempoExecucao=108, DataLancamento= new DateTime(2018,3,2), Imagem="DeathWish.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[7], generos[8] }},
                new Filmes {ID=6, Titulo = "The Forgiven", Descricao="Musawq", TempoExecucao=115, DataLancamento= new DateTime(2018,3,9), Imagem="TheForgiven.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[2], generos[7] }},
                new Filmes {ID=7, Titulo = "Ready Player One: Jogador 1", Descricao="Em 2044, Wade Watts, assim como o resto da humanidade, prefere a realidade virtual do jogo OASIS ao mundo real. ", TempoExecucao=139, DataLancamento= new DateTime(2018,3,29), Imagem="ReadyPlayerOne.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[8], generos[9] }},
                new Filmes {ID=8, Titulo = "As Boas Maneiras", Descricao="Ana contrata Clara, uma solitária enfermeira moradora da periferia de São Paulo, para ser babá de seu filho ainda não nascido. Conforme a gravidez vai avançando, Ana começa a apresentar comportamentos cada vez mais estranhos.", TempoExecucao=135, DataLancamento= new DateTime(2018,3,21), Imagem="PulpFiction.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[0], generos[1] }},
                new Filmes {ID=9, Titulo = "Colo", Descricao="Em Portugal, uma família de classe média passa por uma grave crise financeira. O pai perde o emprego e não consegue encontrar outro trabalho, a mãe consegue acha uma segunda ocupação para aumentar a renda, mas anda sempre cansada e mal para em casa.", TempoExecucao=136, DataLancamento= new DateTime(2017,4,23), Imagem="FightClub.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[1], generos[3] }},
                new Filmes {ID=10, Titulo = "The Jungle Bunch", Descricao="Hnoe.", TempoExecucao=97, DataLancamento= new DateTime(2017,9,7), Imagem="TheJungleBunch.jpg", Video="", RealizadorFK=1, ListaDeGeneros = new List<Generos> { generos[1], generos[3] }},
            };
            filmes.ForEach(ff => context.Filmes.AddOrUpdate(f => f.Titulo, ff));
            context.SaveChanges();

            var personagem = new List<Personagem> {
                 new Personagem { ID=1, MovieFK=1, AtorFK=1, Role="Senhor das Estrelas" },
                 new Personagem { ID=2, MovieFK=1, AtorFK=2, Role="Thanos" },
                 new Personagem { ID=3, MovieFK=1, AtorFK=3, Role="Capitão América" },
                 new Personagem { ID=4, MovieFK=1, AtorFK=4, Role="Thor" },
                 new Personagem { ID=5, MovieFK=1, AtorFK=5, Role="Homem de Ferro" },
                 new Personagem { ID=6, MovieFK=1, AtorFK=6, Role="Viúva Negra" },
                 new Personagem { ID=7, MovieFK=1, AtorFK=7, Role="Thor" },
             };
            personagem.ForEach(pp => context.Personagem.AddOrUpdate(p => p.MovieFK, pp));
            context.SaveChanges();



        }
    }
}