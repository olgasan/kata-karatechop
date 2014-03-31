using UnityEngine;

public class BinarySearch
{
	public int Search (int needle, ISearchable[] elements)
	{
		int[] haystack = SearchableToInt (elements);
		return Search (needle, haystack, 0, haystack.Length-1);
	}

	public int Search (int needle, int[] haystack)
	{
		return Search (needle, haystack, 0, haystack.Length-1);
	}

	private int Search (int needle, int[] haystack, int fromIdx, int toIdx)
	{
		if (toIdx < fromIdx || haystack.Length == 0)
		{
			return -1;
		}
		else
		{
			int middleIdx = GetMiddleIdx (fromIdx, toIdx);
			int middleValue = haystack [middleIdx];

			if (needle < middleValue)
				return Search (needle, haystack, fromIdx, middleIdx-1);

			if (needle > middleValue)
				return Search (needle, haystack, middleIdx+1, toIdx);

			else
				return middleIdx;
		}
	}

	public int GetMiddleIdx (int from, int to)
	{
		int size = to - from;
		return (size / 2) + from;
	}

	private int[] SearchableToInt (ISearchable[] elements)
	{
		int[] haystack = new int[elements.Length];

		for (int i=0; i<elements.Length; i++)
		{
			haystack[i] = elements[i].Index;
		}

		return haystack;
	}
}
