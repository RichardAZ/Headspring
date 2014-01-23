using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Headspring1
{
	[Obsolete("Please use new DivisibleList")]
	public class FizzBuzzEngine 
	{
		private int _start;
		private int _end;
		private Dictionary<int, string> _results = new Dictionary<int, string>();

		public FizzBuzzEngine(int start, int end)
		{
			_start = start;
			_end = end;
		}

		public Dictionary<int, string> GenerateResults()
		{
			for (int i = _start; i <= _end; i++)
			{
				bool isDiv3 = (i % 3 == 0);
				bool isDiv5 = (i % 5 == 0);

				if (isDiv3 && isDiv5)
				{
					_results.Add(i, "FizzBuzz");
					continue;
				}

				if (isDiv3)
				{
					_results.Add(i, "Fizz");
					continue;
				}

				if (isDiv5)
				{
					_results.Add(i, "Buzz");
					continue;
				}

				_results.Add(i, i.ToString());
			}

			return _results;
		}
	}
}
