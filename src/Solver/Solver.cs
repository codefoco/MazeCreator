using MazeCreator.Core;

namespace MazeCreator
{
	public static class  Solver
	{
		public static IMazeSolver Create (IRandomGenerator random = null)
		{
			if (random == null)
				random = new DefaultRandomGenerator ();
			var solver = new DefaultSolver ();
			solver.Random = random;
			return solver;
		}
			
	}
}
