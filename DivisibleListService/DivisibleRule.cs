using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DivisibleListService
{
	public class DivisibleRule
	{
		public DivisibleRule()
		{

		}
		public DivisibleRule(int divisor, string phrase)
		{
			Divisor = divisor;
			Phrase = phrase;
		}

		public int Divisor { get; set; }
		public string Phrase { get; set; }
	}
}
