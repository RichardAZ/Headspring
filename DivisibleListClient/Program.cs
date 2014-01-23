using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DivisibleListService;

namespace Headspring1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("FizzBuzzEngine");
			Console.WriteLine("");

			var engine = new FizzBuzzEngine(1, 100);
			foreach (var item in engine.GenerateResults())
			{
				Console.WriteLine(item.Value);
			}

			Console.WriteLine("");
			Console.WriteLine("DivisibleList");
			Console.WriteLine("");

			DivisibleList list = new DivisibleList(1, 100);

			foreach (DivisibleResult item in list)	
			{
				Console.WriteLine(item.Phrase);
			}

			Console.ReadKey();

		}
	}
}
