using System;
using MazeCreator.Core;

namespace MazeCreator.Creator
{
	public class Prim : ICreator
	{
		public Prim ()
		{
		}

		public Maze Create (int lines, int columns, IRandomGenerator random)
		{
			throw new NotImplementedException ();
		}
	}
}
