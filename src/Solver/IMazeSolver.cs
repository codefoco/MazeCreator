using System;
using MazeCreator.Core;

namespace MazeCreator
{
	public interface IMazeSolver
	{
		PositionDirection[] Solve (Maze maze, Position start, Position end);

		IRandomGenerator Random { get; set; }

		Action<Maze, Position> PositionVisited { get; set; }
		Action<Maze, Position> WalkBack { get; set; }
	}
}
