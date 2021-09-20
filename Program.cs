
using System;

namespace APP_Cadastro_de_Serie
{
    class Program
    {
        static SerirRepositorio repositorio = new SerirRepositorio();
        static void Main(string[] args)
        {
            
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarSerie();

                        break;
                    case "2":
                        InserirSerie();

                        break;
                    case "3":
                        ActualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();

                        break;
                    default:
                        throw new ArgumentException();
                }

                OpcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar os nossos serviços");
            Console.ReadKey();
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar Serie");
            var lista = repositorio.lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie Cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine("Id:{0}: - {1}", serie.RetornaId(), serie.RetornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.proximoId(),genero: (Genero)entradaGenero,titulo: entradaTitulo,
                                       ano: entradaAno, descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

        }

        private static void ActualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Actualizar(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.retornaporId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(" Práticas - Séries a seu dispor!!!");
            Console.WriteLine();
            Console.WriteLine(" Práticas - Informa a Opção Desejada: ");
            Console.WriteLine();
            Console.WriteLine("1- Listar Series");
            Console.WriteLine("2-Inserir Nova Serie");
            Console.WriteLine("3-Actualizar Serie");
            Console.WriteLine("4- Excluir Series");
            Console.WriteLine("5- Visualizar Serie");
            Console.WriteLine("C- Limpar Serie");
            Console.WriteLine("X Sair");
            Console.WriteLine();
            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
          
            return OpcaoUsuario;
        }
    }
}
