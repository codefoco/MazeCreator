using System;

namespace MazeCreator.Core
{
	public class DefaultRandomGenerator : IRandomGenerator
	{
		Random random = new Random ();

		public int Next (int max)
		{
			return random.Next (max);
		}
	}
}
