using System;
using DIO_Desafio_Series;

internal class Program
{
    static SerieRepositorio repositorioSerie = new SerieRepositorio();
    static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
    private static void Main()
    {
        string opcaoMenuPrincipal = ObterOpcaoUsuario();
        string opcaoUsuario = TratarOpcaoUsuario(opcaoMenuPrincipal);
        while (opcaoMenuPrincipal.ToUpper() != "X" && opcaoUsuario.ToUpper() != "X")
        {
            if (opcaoMenuPrincipal == "1")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.Clear();
                        ListarFilmes();
                        break;
                    case "2":
                        Console.Clear();
                        InserirFilme();
                        break;
                    case "3":
                        Console.Clear();
                        AtualizarFilme();
                        break;
                    case "4":
                        Console.Clear();
                        ExcluirFilme();
                        break;
                    case "5":
                        Console.Clear();
                        VisualizarFilme();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (opcaoMenuPrincipal == "2")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.Clear();
                        ListarSeries();
                        break;
                    case "2":
                        Console.Clear();
                        InserirSerie();
                        break;
                    case "3":
                        Console.Clear();
                        AtualizarSerie();
                        break;
                    case "4":
                        Console.Clear();
                        ExcluirSerie();
                        break;
                    case "5":
                        Console.Clear();
                        VisualizarSerie();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            if(opcaoUsuario.ToUpper() != "6")
            {
                opcaoUsuario = TratarOpcaoUsuario(opcaoMenuPrincipal);
            }
            else 
            {
                opcaoMenuPrincipal = ObterOpcaoUsuario();
                opcaoUsuario = TratarOpcaoUsuario(opcaoMenuPrincipal);
            }
        }
        Console.WriteLine("Obrigado por usar nossos serviços.");
        Console.ReadLine();
    }
    //Filmes
    private static void ListarFilmes()
    {
        Console.WriteLine("Listar filmes");

        var lista = repositorioFilme.Lista();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum filme cadastrado. \n");
            return;
        }

        foreach (var filme in lista)
        {
            var excluido = filme.retornaExcluido();
            Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*" : ""));
        }
        Console.WriteLine();
    }
    private static void InserirFilme()
    {
        Console.WriteLine("Inserir novo filme");

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }

        Console.Write("Digite o gênero dentre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o título do filme: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de lançamento do filme: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição do filme: ");
        string entradaDescricao = Console.ReadLine();

        Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorioFilme.Insere(novoFilme);
        Console.Clear();
    }
    private static void ExcluirFilme()
    {
        Console.Write("Digite o id do filme:");
        int indiceFilme = int.Parse(Console.ReadLine());

        repositorioFilme.Exclui(indiceFilme);
    }
    private static void VisualizarFilme()
    {
        Console.Write("Digite o id do filme: ");
        int indiceFilme = int.Parse(Console.ReadLine());

        var filme = repositorioFilme.RetornaPorId(indiceFilme);

        Console.WriteLine(filme + "\n");
    }
    private static void AtualizarFilme()
    {
        var lista = repositorioFilme.Lista();

        if (lista.Count == 0)
        {
            Console.WriteLine("Apenas filmes cadastrados podem ser atualizados.\nConsulte a seção 'Listar Filmes' para ver os filmes cadastrados e/ou deletados. \n");
            return;
        }

        Console.Write("Digite o id do filme: ");
        int indiceFilme = int.Parse(Console.ReadLine());

        for (var i = 0; i < lista.Count; i++)
        {
            lista.ToArray();
            if (lista[indiceFilme].retornaExcluido())
            {
                Console.WriteLine("Filmes excluídos não podem ser atualizados! \n");
                return;
            }
        }

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o título do filme: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de lançamento do filme: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição do filme: ");
        string entradaDescricao = Console.ReadLine();

        Filme atualizaFilme = new Filme(id: indiceFilme,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
        Console.Clear();
    }

    //Séries
    private static void ListarSeries()
    {
        System.Console.WriteLine("Listar séries");

        var lista = repositorioSerie.Lista();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhuma série cadastrada. \n");
            return;
        }

        foreach (var serie in lista)
        {
            var excluido = serie.retornaExcluido();
            Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
        }
        Console.WriteLine();
    }

    private static void InserirSerie()
    {
        Console.WriteLine("Inserir nova série");

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }

        Console.Write("Digite o primeiro gênero dentre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o título da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de início da série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        Serie novaSerie = new Serie(id: repositorioSerie.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorioSerie.Insere(novaSerie);
        Console.Clear();
    }

    private static void ExcluirSerie()
    {
        Console.Write("Digite o id da série:");
        int indiceSerie = int.Parse(Console.ReadLine());

        repositorioSerie.Exclui(indiceSerie); 
        Console.Clear();   
    }

    private static void VisualizarSerie()
    {
        Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repositorioSerie.RetornaPorId(indiceSerie);

        Console.WriteLine(serie + "\n");
    }

    private static void AtualizarSerie()
    {
        var lista = repositorioSerie.Lista();

        if (lista.Count == 0)
        {
            Console.WriteLine("Apenas séries cadastradas podem ser atualizadas.\nConsulte a seção 'Listar Séries' para ver as séries cadastradas e/ou deletadas. \n");
            return;
        }

        Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        for (var i = 0; i < lista.Count; i++)
        {
            lista.ToArray();
            if (lista[indiceSerie].retornaExcluido())
            {
                Console.WriteLine("Séries excluídas não podem ser atualizadas! \n");
                return;
            }
        }

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o título da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de início da série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        Serie atualizaSerie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
        Console.Clear();
    }
    private static string ObterOpcaoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("DIO Séries a seu dispor!!!");
        Console.WriteLine("Escolha a aba desejada: ");
        Console.WriteLine("1 - Filmes");
        Console.WriteLine("2 - Séries");
        Console.WriteLine("X - Sair");

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.Clear();
        return opcaoUsuario;
    }

    private static string TratarOpcaoUsuario(string opcaoUsuario)
    {
        switch (opcaoUsuario.ToUpper())
        {
            case "1":
                Console.WriteLine("Informe a opção desejada: ");

                Console.WriteLine("1 - Listar filmes");
                Console.WriteLine("2 - Inserir novo filme");
                Console.WriteLine("3 - Atualizar filme");
                Console.WriteLine("4 - Excluir filme");
                Console.WriteLine("5 - Visualizar filme");
                Console.WriteLine("6 - Voltar ao menu principal");
                Console.WriteLine("C - Limpar tela");
                Console.WriteLine("X - Sair");
                Console.WriteLine();
                opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            case "2":
                Console.WriteLine("Informe a opção desejada: ");

                Console.WriteLine("1 - Listar séries");
                Console.WriteLine("2 - Inserir nova série");
                Console.WriteLine("3 - Atualizar série");
                Console.WriteLine("4 - Excluir série");
                Console.WriteLine("5 - Visualizar série");
                Console.WriteLine("6 - Voltar ao menu principal");
                Console.WriteLine("C - Limpar tela");
                Console.WriteLine("X - Sair");
                Console.WriteLine();
                opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            case "X":
                return opcaoUsuario;
        }
        throw new ArgumentOutOfRangeException();
    }
}