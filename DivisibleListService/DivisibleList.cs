using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleListService
{
	public class DivisibleList : IEnumerable
	{
		public int Start { get; set; }
		public int End { get; set; }
		public List<DivisibleRule> Rules { get; set; }

		private void CheckArguments()
		{
			if (Start < 1)
			{
				throw new ArgumentException("start argument must be above 0");
			}

			if (End < 1)
			{
				throw new ArgumentException("end argument must be above 0");
			}
		}

		public DivisibleList(int start, int end)
		{
			Start = start;
			End = end;
			Rules = new List<DivisibleRule>();

			//Use 3 = Fizz and 5 = Buzz by default
			Rules.Add(new DivisibleRule(3, "Fizz"));
			Rules.Add(new DivisibleRule(5, "Buzz"));

			CheckArguments();
		}

		public DivisibleList(int start, int end, List<DivisibleRule> rules)
		{
			Start = start;
			End = end;
			Rules = rules;

			CheckArguments();
		}

		public IEnumerator GetEnumerator()
		{
			return new DivisibleEnumerator(this);
		}
	}
}
