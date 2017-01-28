using System;
using MazeCreator.Creator;

namespace MazeCreator.Core
{
	public enum Algorithm
	{
		DFS,
		Prim,
		Kruskal
	}

	public static class Creator
	{
		public static Maze Create (int lines, int columns, Algorithm algoritm = Algorithm.DFS, IRandomGenerator random = null)
		{
			if (random == null)
				random = new DefaultRandomGenerator ();

			ICreator creator = GetCreator (algoritm);
			return creator.Create (lines, columns, random);
		}

		static ICreator GetCreator (Algorithm algorithm)
		{
			switch (algorithm) {
			case Algorithm.DFS:
				return new DFS ();
			case Algorithm.Prim:
				return new Prim ();
			case Algorithm.Kruskal:
				return new Kruskal ();
			}
			throw new InvalidOperationException ("Invalid algorithm parameter");
		}
	}
}
