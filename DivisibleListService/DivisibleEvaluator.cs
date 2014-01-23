using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleListService
{

	public interface IDivisibleEvaluator
	{
		string Evaluate(int value);
	}
	public class DivisibleEvaluator: IDivisibleEvaluator
	{
		private IEnumerable<DivisibleRule> _rules;

		public DivisibleEvaluator(IEnumerable<DivisibleRule> rules)
		{
			_rules = rules;
		}

		public string Evaluate(int value)
		{
			StringBuilder result = new StringBuilder();

			foreach (var rule in _rules)
			{							
				if (value % rule.Divisor == 0)
				{
					result.Append(rule.Phrase);
				}
			}

			if (result.Length > 0)
			{
				return result.ToString();
			}
			//if no rules pass, then return value
			else
			{
				return value.ToString();
			}
		}
	}
}
