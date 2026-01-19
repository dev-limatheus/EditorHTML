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
			}
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.WriteLine("----------------------------------------");
            Viewer.Show(file.ToString());
        }

		public static void Save(string text)
		{
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("- Deseja salvar o arquivo? (S/N)");
			string res = Console.ReadLine().ToLower();

			if (res == "s")
			{
				Console.Clear();
				Console.WriteLine(@" Qual caminho e nome do arquivo? (Ex: caminho\nomedoarquivo.html)");
				string path = Console.ReadLine();


				using (var arquivo = new StreamWriter(path))
				{
					arquivo.Write(text);
				}

				Console.WriteLine($"Arquivo salvo em '{path}' com sucesso!");
				Console.WriteLine($"Retornando ao MENU");
				Thread.Sleep(3000);

				Menu.Show();
			}

			if (res == "n")
			{
				Console.WriteLine("Arquivo descartado, retornando ao menu.");
				Thread.Sleep(3000);
				Menu.Show();
			}

			else
			{
				Console.WriteLine("Op��o incorreta.");
				Save(text);
			}

		}
	}
}