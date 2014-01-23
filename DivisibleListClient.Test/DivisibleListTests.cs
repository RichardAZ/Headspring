using System;
using System.Collections.Generic;
using System.Diagnostics;
using DivisibleListService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DivisibleListClient.Test
{
	[TestClass]
	public class DivisibleListTests
	{
		private List<DivisibleRule> _testRules;
		private List<DivisibleRule> _testRulesPrimes;

		[TestInitialize]
		public void Init()
		{
			_testRules = new List<DivisibleRule>
			{
				new DivisibleRule(2, "Cat"),
				new DivisibleRule(5, "Dog"),
				new DivisibleRule(7, "Cow")
			};
			
			_testRulesPrimes = new List<DivisibleRule>
			{
				new DivisibleRule(2, "X"),
				new DivisibleRule(3, "X"),
				new DivisibleRule(5, "X"),
				new DivisibleRule(7, "X")
			};
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void TestCheckArguments()
		{
			var list = new DivisibleList(-5, -10);
		}

		[TestMethod]
		public void TestList()
		{
			var results = new Dictionary<int, string>();
			var list = new DivisibleList(1, 100, _testRules);

			foreach (DivisibleResult item in list)
			{
				results.Add(item.Value, item.Phrase);
			}

			Assert.IsTrue(results[7] == "Cow");
		}

		[TestMethod]
		public void TestFizzBuzzDefault()
		{
			var results = new Dictionary<int, string>();
			var list = new DivisibleList(1, 100);

			foreach (DivisibleResult item in list)
			{
				results.Add(item.Value, item.Phrase);
			}

			Assert.AreEqual(results[7], "7");
			Assert.AreEqual(results[5], "Buzz");
		}

		[TestMethod]
		public void TestPrimes()
		{
			var primes = new List<int>();
			var list = new DivisibleList(1, 100, _testRulesPrimes);

			foreach (DivisibleResult item in list)
			{
				if (_testRulesPrimes.Any(r => r.Divisor == item.Value) || item.IsDivisible == false)
				{
					primes.Add(item.Value);
				}
			}

			Assert.IsTrue(primes.Contains(2));
			Assert.IsTrue(primes.Contains(31));
			Assert.IsFalse(primes.Contains(10));
		}

		[TestMethod]
		public void TestLargeRange()
		{
			int count = 0;
			bool passed10000 = false;

			var list = new DivisibleList(1, Int32.MaxValue);

			foreach (DivisibleResult item in list)
			{
				count++;

				if (count > 10000)
				{
					passed10000 = true;
					break;
				}
			}

			Assert.IsTrue(passed10000);
		}
	}
}
