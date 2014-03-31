using UnityEngine;
using NUnit.Framework;

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
			int[] haystack = {};
			Assert.AreEqual (-1, b.Search (1, haystack));
		}

		[Test]
		public void SearchOneSizedArray ()
		{
			int[] haystack = {2};
			Assert.AreEqual (0, b.Search (2, haystack));
			Assert.AreEqual (-1, b.Search (1, haystack));
		}

		[Test]
		public void SearchIntoArray ([Values (0, 1, 4, 6)] int a)
		{
			int[] haystack = {1, 2, 3, 4, 5, 6};
			Assert.AreEqual (a-1, b.Search (a, haystack));
		}

		[Test]
		public void FindMiddleIdxBetweenTwoPoints()
		{
			Assert.AreEqual (4, b.GetMiddleIdx (2, 6));
			Assert.AreEqual (0, b.GetMiddleIdx (0, 1));
			Assert.AreEqual (3, b.GetMiddleIdx (3, 4));
		}
	}
}
