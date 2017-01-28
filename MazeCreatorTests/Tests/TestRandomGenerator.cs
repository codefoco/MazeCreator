using System;
using MazeCreator.Core;

namespace MazeCreatorTest.Tests
{
	public class TestRandomGenerator : IRandomGenerator
	{
		Random random = new Random (37);

		public int Next (int max)
		{
			return random.Next (max);
		}
	}
	
}
