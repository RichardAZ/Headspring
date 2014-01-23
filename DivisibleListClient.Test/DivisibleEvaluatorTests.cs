using System;
using System.Collections.Generic;
using DivisibleListService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DivisibleListClient.Test
{
	[TestClass]
	public class DivisibleEvaluatorTests
	{
		private List<DivisibleRule> _testRules = new List<DivisibleRule>();

		[TestInitialize]
		public void Init()
		{
			_testRules.Add(new DivisibleRule()
			{
				Divisor = 2,
				Phrase = "Cat"
			});

			_testRules.Add(new DivisibleRule()
			{
				Divisor = 5,
				Phrase = "Dog"
			});

			_testRules.Add(new DivisibleRule()
			{
				Divisor = 7,
				Phrase = "Cow"
			});
		}

		[TestMethod]
		public void TestEvaluator()
		{
			var evaluator = new DivisibleEvaluator(_testRules);

			Assert.IsTrue(evaluator.Evaluate(10) == "CatDog");
			Assert.IsTrue(evaluator.Evaluate(13) == "13");
			Assert.IsTrue(evaluator.Evaluate(70) == "CatDogCow");

		}
	}
}
