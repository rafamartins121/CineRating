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
                new Generos {ID=1, Nome="Ação" },
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

            var diretores = new List<Diretores> {
                new Diretores {ID=1, Nome = "Steven Spielberg", DataNascimento=new DateTime(1946,12,18), Biografia="Steven Allan Spielberg é um premiado cineasta, produtor cinematográfico, roteirista e empresário norte-americano."},
                new Diretores {ID=2, Nome = "Quentin Tarantino", DataNascimento=new DateTime(1963,3,27), Biografia="Quentin Jerome Tarantino é um cineasta, roteirista e ator americano. Alcançou a fama rapidamente no início da década de 1990 por seus roteiros não-lineares, diálogos memoráveis e o uso de violência."},
                new Diretores {ID=3, Nome = "Martin Scorsese", DataNascimento=new DateTime(1942,11,17), Biografia="Martin Scorsese é um premiado cineasta, produtor de cinema, roteirista e ator norte-americano. É considerado como um dos maiores diretores de todos os tempos."},
                new Diretores {ID=4, Nome = "Alfred Hitchcock", DataNascimento=new DateTime(1899,8,13), Biografia="Alfred Joseph Hitchcock, foi um cineasta britânico. Considerado o 'Mestre do suspense', foi um dos mais conhecidos e populares realizadores de filmes desse gênero de todos os tempos."},
                new Diretores {ID=5, Nome = "Christopher Nolan", DataNascimento=new DateTime(1970,7,30), Biografia="Christopher Edward Nolan é um cineasta, roteirista e produtor anglo-americano. "},
                new Diretores {ID=6, Nome = "James Cameron", DataNascimento=new DateTime(1954,8,16), Biografia="James Francis Cameron é um cineasta, produtor, roteirista e editor canadense."},
                new Diretores {ID=7, Nome = "David Lynch", DataNascimento=new DateTime(1946,1,20), Biografia="David Keith Lynch é um diretor, roteirista, produtor, artista visual, músico e ocasional ator estadunidense."},
                new Diretores {ID=8, Nome = "George Lucas", DataNascimento=new DateTime(1944,5,14), Biografia="George Walton Lucas Jr. é um produtor cinematográfico, roteirista e diretor de cinema norte-americano."},
                new Diretores {ID=9, Nome = "Stanley Kubrick", DataNascimento=new DateTime(1928,7,26), Biografia="Stanley Kubrick foi um cineasta, roteirista, produtor de cinema e fotógrafo americano."},
                new Diretores {ID=10, Nome = "Ron Howard", DataNascimento=new DateTime(1954,3,1), Biografia="Ronald William Howard é um ator, cineasta e produtor de cinema norte-americano."},
            };
            diretores.ForEach(dd => context.Diretores.AddOrUpdate(d => d.Nome, dd));
            context.SaveChanges();

            var atores = new List<Atores> {
                new Atores {ID=1, Nome = "Leonardo DiCaprio", DataNascimento=new DateTime(1974,11,11), Biografia="Leonardo Wilhelm DiCaprio é um premiado ator, produtor e filantropo norte-americano vencedor do Oscar de melhor ator com o filmeThe Revenant. "},
                new Atores {ID=2, Nome = "Johnny Depp", DataNascimento=new DateTime(1963,6,9), Biografia="John 'Johnny' Christopher Depp II é um premiado ator, músico, produtor de cinema e diretor americano."},
                new Atores {ID=3, Nome = "Tom Hanks", DataNascimento=new DateTime(1956,7,9), Biografia="Thomas Jeffrey Hanks, mais conhecido como Tom Hanks é um premiado ator, produtor, roteirista e diretor americano."},
                new Atores {ID=4, Nome = "Brad Pitt", DataNascimento=new DateTime(1963,12,18), Biografia="William Bradley 'Brad' Pitt é um ator e produtor americano. É vencedor de um Oscar, um Prêmio Screen Actors Guild, um Prêmio Globo de Ouro e BAFTA e constantemente citado como um dos mais bem pagos atores de Hollywood."},
                new Atores {ID=5, Nome = "Robert Downey Jr.", DataNascimento=new DateTime(1965,4,4), Biografia="Robert John Downey, Jr. é um premiado ator, cantor, compositor e pianista americano. Estreou como ator em 1970 aos 5 anos, no filme Pound, dirigido por seu pai, Robert Downey, Sr."},
                new Atores {ID=6, Nome = "Tom Cruise", DataNascimento=new DateTime(1962,7,3), Biografia="Tom Cruise é um ator e produtor de cinema norte-americano. Listado pela revista Forbes como a celebridade mais popular de 2006, foi indicado por três vezes para o Oscar e venceu três Globos de Ouro."},
                new Atores {ID=7, Nome = "Christian Bale", DataNascimento=new DateTime(1974,1,30), Biografia="Christian Charles Philip Bale é um ator britânico. Em 2011, ele venceu Oscar de Melhor Ator Coadjuvante, o Globo de Ouro de Melhor Ator Coadjuvante e o SAG Award de Melhor Ator Coadjuvante pela atuação como Dicky Eklund na cinebiografia The Fighter."},
                new Atores {ID=8, Nome = "Daniel Day-Lewis", DataNascimento=new DateTime(1957,4,29), Biografia="Sir Daniel Michael Blake Day-Lewis, é um premiado ator britânico, com dupla nacionalidade."},
                new Atores {ID=9, Nome = "Russell Crowe", DataNascimento=new DateTime(1964,4,7), Biografia="Russell Ira Crowe é um ator e produtor de cinema neozelandês. Depois do sucesso inicial na Austrália, onde sua família mora desde sua infância, tornou-se um ator de Hollywood no meio da década de 1990."},
                new Atores {ID=10, Nome = "Matt Damon", DataNascimento=new DateTime(1970,10,8), Biografia="Matthew 'Matt' Paige Damon é um ator, roteirista, produtor e filantropo norte-americano, cuja carreira foi lançada após o sucesso do filme de drama Good Will Hunting a partir do roteiro que ele co-escreveu com o amigo e ator Ben Affleck."},
            };
            atores.ForEach(att => context.Atores.AddOrUpdate(at => at.Nome, att));
            context.SaveChanges();

            var filmes = new List<Filmes> {
                new Filmes {ID=1, Titulo = "Vingadores: Guerra do Infinito", Descricao="Homem de Ferro, Thor, Hulk e os Vingadores se unem para combater seu inimigo mais poderoso, o maligno Thanos. Em uma missão para coletar todas as seis pedras infinitas, Thanos planeja usá-las para infligir sua vontade maléfica sobre a realidade.", TempoExecucao=160, DataLancamento= new DateTime(2018,4,23), Imagem="", Video="", DiretorFK=1},
                new Filmes {ID=2, Titulo = "Um Lugar Silencioso", Descricao="Em uma fazenda nos Estados Unidos, uma família do Meio-Oeste é perseguida por uma entidade fantasmagórica assustadora. Para se protegerem, eles devem permanecer em silêncio absoluto, a qualquer custo, pois o perigo é ativado pela percepção do som.", TempoExecucao=95, DataLancamento= new DateTime(2018,4,3), Imagem="", Video="", DiretorFK=2},
                new Filmes {ID=3, Titulo = "Beirut", Descricao="Beirut é um filme de drama estadunidense de 2018 dirigido e escrito por Brad Anderson e Tony Gilroy. Estrelado por Jon Hamm, Rosamund Pike, Dean Norris e Shea Whigham, estreou no Festival Sundance de Cinema em 22 de janeiro de 2018.", TempoExecucao=109, DataLancamento= new DateTime(2018,4,11), Imagem="", Video="", DiretorFK=3},
                new Filmes {ID=4, Titulo = "Rampage: Fora de Controle", Descricao="Davis Okoye é um primatologista, um homem recluso que compartilha um vínculo inabalável com George, um gorila muito inteligente que está sob seus cuidados desde o nascimento.", TempoExecucao=115, DataLancamento= new DateTime(2018,4,12), Imagem="", Video="", DiretorFK=4},
                new Filmes {ID=5, Titulo = "Desejo de Matar", Descricao="Após ter sua casa invadida e esposa assassinada por bandidos, Paul passa a acompanhar a polícia nas investigações para capturar os criminosos.", TempoExecucao=108, DataLancamento= new DateTime(2018,3,2), Imagem="", Video="", DiretorFK=5},
                new Filmes {ID=6, Titulo = "The Forgiven", Descricao="Musawq", TempoExecucao=115, DataLancamento= new DateTime(2018,3,9), Imagem="", Video="", DiretorFK=6},
                new Filmes {ID=7, Titulo = "Ready Player One: Jogador 1", Descricao="Em 2044, Wade Watts, assim como o resto da humanidade, prefere a realidade virtual do jogo OASIS ao mundo real. ", TempoExecucao=139, DataLancamento= new DateTime(2018,3,29), Imagem="", Video="", DiretorFK=7},
                new Filmes {ID=8, Titulo = "As Boas Maneiras", Descricao="Ana contrata Clara, uma solitária enfermeira moradora da periferia de São Paulo, para ser babá de seu filho ainda não nascido. Conforme a gravidez vai avançando, Ana começa a apresentar comportamentos cada vez mais estranhos.", TempoExecucao=135, DataLancamento= new DateTime(2018,3,21), Imagem="", Video="", DiretorFK=8},
                new Filmes {ID=9, Titulo = "Colo", Descricao="Em Portugal, uma família de classe média passa por uma grave crise financeira. O pai perde o emprego e não consegue encontrar outro trabalho, a mãe consegue acha uma segunda ocupação para aumentar a renda, mas anda sempre cansada e mal para em casa.", TempoExecucao=136, DataLancamento= new DateTime(2017,4,23), Imagem="", Video="", DiretorFK=9},
                new Filmes {ID=10, Titulo = "The Jungle Bunch", Descricao="Hnoe.", TempoExecucao=97, DataLancamento= new DateTime(2017,9,7), Imagem="", Video="", DiretorFK=10},
            };
            filmes.ForEach(ff => context.Filmes.AddOrUpdate(f => f.Titulo, ff));
            context.SaveChanges();




        }
    }
}