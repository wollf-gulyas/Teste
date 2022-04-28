using System;

namespace TESTE.Sorvete
{
    class Program
    {
        static SorveteRepositorio repositorio = new SorveteRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSorvete();
						break;
					case "2":
						InserirSorvete();
						break;
					case "3":
						AtualizarSorvete();
						break;
					case "4":
						ExcluirSorvete();
						break;
					case "5":
						VisualizarSorvete();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}
				opcaoUsuario = ObterOpcaoUsuario();
			}
			Console.WriteLine("Obrigado.");
			Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Informe a opção:");

			Console.WriteLine("1 - Listar sorvete");
			Console.WriteLine("2 - Inserir novo sorvete");
			Console.WriteLine("3 - Atualizar sorvete");
			Console.WriteLine("4 - Excluir sorvete");
			Console.WriteLine("5 - Visualizar sorvete");
			Console.WriteLine("C - Limpar Tela");
			Console.WriteLine("X - Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			
			return opcaoUsuario;
		}

        private static void ListarSorvete()
		{
			Console.WriteLine("Listar sorvete");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum sorvete cadastrado.");
				return;
			}

			foreach (var sorvete in lista)
			{
                var excluido = sorvete.retornaExcluido();
				Console.WriteLine("#ID {0}: - {1} {2}", sorvete.retornaId(), sorvete.retornaSabor(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSorvete()
		{
			Console.WriteLine("Inserir novo sorvete");

			foreach (int i in Enum.GetValues(typeof(Sabor)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Sabor), i));
			}

			Console.Write("Digite o sabor entre as opções acima: ");
			int entradaSabor = int.Parse(Console.ReadLine());


			Console.Write("Digite a Descrição do sorvete: ");
			string entradaDescricao = Console.ReadLine();

			Sorvete novoSorvete = new Sorvete(id: repositorio.ProximoId(),
										sabor: (Sabor)entradaSabor,
										
										descricao: entradaDescricao);

			repositorio.Insere(novoSorvete);
		}

        private static void AtualizarSorvete()
		{
			Console.Write("Digite o ID do sorvete: ");
			int indiceSorvete = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Sabor)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Sabor), i));
			}

			Console.Write("Digite o sabor entre as opções acima: ");
			int entradaSabor = int.Parse(Console.ReadLine());

			
			Console.Write("Digite a Descrição do Sorvete:");
			string entradaDescricao = Console.ReadLine();

			Sorvete atualizaSorvete = new Sorvete(id: indiceSorvete,
										sabor: (Sabor)entradaSabor,
										
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSorvete, atualizaSorvete);
		}

        private static void ExcluirSorvete()
		{
			Console.Write("Digite o ID do sorvete: ");
			int indiceSorvete = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSorvete);
		}

        private static void VisualizarSorvete()
		{
			Console.Write("Digite o ID do sorvete: ");
			int indiceSorvete = int.Parse(Console.ReadLine());

			var sorvete = repositorio.RetornaPorId(indiceSorvete);
			Console.WriteLine(sorvete);
		}
    }
}