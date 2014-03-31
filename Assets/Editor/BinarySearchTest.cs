using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

namespace UnityTest
{
	internal class BinarySearchTest 
	{
		private BinarySearch b;

		[SetUp]
		public void SetUp ()
		{
			b = new BinarySearch ();
		}

		[Test]
		public void SearchOnEmptyArray ()
		{
			ISearchable[] haystack = {};
			Assert.AreEqual (-1, b.Search (1, haystack));
		
			int[] haystackInt = {};
			Assert.AreEqual (-1, b.Search (1, haystackInt));
		}

		[Test]
		public void SearchOneSizedArray ()
		{
			ISearchable[] haystack = CreateFakeSearchable (2);
			Assert.AreEqual (0, b.Search (2, haystack));
			Assert.AreEqual (-1, b.Search (1, haystack));
		}

		[Test]
		public void SearchIntoArray ([Values (0, 1, 4, 6)] int a)
		{
			ISearchable[] haystack = CreateFakeSearchable (1, 2, 3, 4, 5, 6);
			Assert.AreEqual (a-1, b.Search (a, haystack));

			int[] haystackInt = {1, 2, 3, 4, 5, 6};
			Assert.AreEqual (a-1, b.Search (a, haystackInt));
		}

		[Test]
		public void FindMiddleIdxBetweenTwoPoints()
		{
			Assert.AreEqual (4, b.GetMiddleIdx (2, 6));
			Assert.AreEqual (0, b.GetMiddleIdx (0, 1));
			Assert.AreEqual (3, b.GetMiddleIdx (3, 4));
		}

		private ISearchable CreateFakeSearchable ()
		{
			return Substitute.For<ISearchable> ();
		}

		private ISearchable[] CreateFakeSearchable (params int[] values)
		{
			ISearchable[] elements = new ISearchable[values.Length];

			for (int i=0; i<values.Length; i++)
			{
				var element = Substitute.For<ISearchable> ();
				element.Index.Returns (values[i]);
				elements[i] = element;
			}

			return elements;
		}
	}
}
