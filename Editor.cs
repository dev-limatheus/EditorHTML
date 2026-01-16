using System.Text;

namespace EditorHTML
{
	public static class Editor
	{
		public static void Show()
		{
			Console.Clear();
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Clear();
			Console.WriteLine("MODO EDITOR - (ESC - Para sair)");
			Console.WriteLine("------------");
			Console.WriteLine("Digite seu texto");
			Console.WriteLine("------------");

			Start();
		}

		public static void Start()
		{
			var file = new StringBuilder();

			do 
			{ 
				file.Append(Console.ReadLine());
				file.Append(Environment.NewLine);
			} while (Console.ReadKey().Key != ConsoleKey.Escape);

			Console.WriteLine("--------------");

			WantSave();

		}

		public static void WantSave() {

			Console.WriteLine(" Deseja salvar o arquivo? (S/N)");
			string res = Console.ReadLine().ToLower();

			if (res == "s")
			{
				Save();
			}

			if (res == "n")
			{
				Console.WriteLine("Arquivo descartado, retornando ao menu.");
				Thread.Sleep(3000);
				Menu.Show();
			}

			else
			{
				Console.WriteLine("Opção incorreta.");
				WantSave();
			}

		}

		public static void Save() {
			Console.Clear();
			Console.WriteLine("Qual caminho e nome do arquivo? (Ex: caminho\nomedoarquivo.html)");
			string path = Console.ReadLine();

			using (var file = new StreamWriter(path))
			{
				file.Write();
			}

			Console.WriteLine($"Arquivo salvo em '{path}' com sucesso!");
			Console.ReadLine();

			Menu.Show();
		}




	}
}