using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleListService
{
	public class DivisibleEnumerator: IEnumerator
	{
		private DivisibleList _list;
		
		//TODO: Use DI to resolve
		private IDivisibleEvaluator _evaluator;
		private int? _current;

		public DivisibleEnumerator(DivisibleList list)
		{
			_list = list;
			_current = list.Start;
			_evaluator = new DivisibleEvaluator(_list.Rules);
		}

		public bool MoveNext()
		{
			_current++;

			if (_current > _list.End)
			{
				_current = null;
				return false;
			}

			return true;
		}

		public void Reset()
		{
			_current = _list.Start;
		}

		public void Dispose()
		{
			_evaluator = null;
		}

		public DivisibleResult Current
		{
			get
			{
				if (_current == null)
				{
					return null;
				}

				var result = _evaluator.Evaluate(_current.Value);

				return new DivisibleResult
				{
					Value = _current.Value,
					Phrase = result,
					IsDivisible = (result != _current.ToString())
				};
			}
		}

		object IEnumerator.Current
		{
			get 
			{
				return (object)this.Current;
			}
		}
	}
}
