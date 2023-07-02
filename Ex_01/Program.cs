using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_01
{
	struct Worker
	{
		public string Name { get; set; }
		public string Post { get; set; }
		public int YearOfEntry { get; set; }

		public Worker(string name, string post, int year)
		{
			Name = name;
			Post = post;
			YearOfEntry = year;
		}
	}
	static class JoinWorker
	{
		static Worker AddWorker(string name, string post, int year)
		{
			return new Worker(name, post, year);
		}

		public static Worker SetWorker()
		{
			string name, post;
			int year;
			Console.WriteLine("Введите фамилию и инициал работника: ");
			name = Console.ReadLine();
			Console.WriteLine("Введите должность работника: ");
			post = Console.ReadLine();

			while (true)
			{
				try
				{
					Console.WriteLine("Введите год поступления на работу: ");
					year = Int32.Parse(Console.ReadLine());
					if (year > 2023 || year < 2010)
					{
						throw new WrongDateException();
					}
					break;
				}
				catch (WrongDateException e)
				{
					Console.WriteLine(e.Message);
				}
			}
			Console.WriteLine("Успешно зарегистрировано!");
			return AddWorker(name, post, year);
		}
	}
	class WrongDateException : Exception
	{
		public new string Message = "Введен неправильный год";
	}
	class Program
	{
		static void Main(string[] args)
		{
			Worker[] workers = new Worker[5];
			for (int i = 0; i < 5; i++)
			{
				workers[i] = JoinWorker.SetWorker();
			}
			Console.ReadKey();
		}
	}
}
