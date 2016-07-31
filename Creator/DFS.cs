using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeCreator
{
	public class DFS : ICreator
	{
		Direction [] GetAvailableDirections (Maze maze, Position position)
		{
			var directions = new List<Direction> ();

			if (CanGoUp (position, maze))
				directions.Add (Direction.Up);
			if (CanGoLeft (position, maze))
				directions.Add (Direction.Left);
			if (CanGoDown (position, maze))
				directions.Add (Direction.Down);
			if (CanGoRight (position, maze))
				directions.Add (Direction.Right);
			
			return directions.ToArray ();
		}

		bool CanGoUp (Position position, Maze maze)
		{
			Cell cell = maze [position];
			return !cell.HasTopBorder && maze [position.Up].HasAllWalls;
		}

		bool CanGoLeft (Position position, Maze maze)
		{
			Cell cell = maze [position];
			return !cell.HasLeftBorder && maze [position.Left].HasAllWalls;
		}

		bool CanGoDown (Position position, Maze maze)
		{
			Cell cell = maze [position];
			return !cell.HasBottomBorder && maze [position.Down].HasAllWalls;
		}

		bool CanGoRight (Position position, Maze maze)
		{
			Cell cell = maze [position];
			return !cell.HasRightBorder && maze [position.Right].HasAllWalls;
		}

		Direction GetRandomDirection (Direction [] directions, IRandomGenerator random)
		{
			if (directions.Length == 1)
				return directions [0];
			return directions [random.Next (directions.Length)];
		}

		void RemoveWalls (Position position, Position nextPosition, Direction direction, Maze maze)
		{
			Cell start = maze [position];
			Cell end   = maze [nextPosition];

			start.RemoveStartWall (direction);
			end.RemoveEndWall (direction);

			maze [position] = start;
			maze [nextPosition] = end;
		}


		public Maze Create (int lines, int columns, IRandomGenerator random)
		{
			Maze maze = new Maze (lines, columns);
			var position = Position.RandomPosition (lines, columns, random);

			int totalCells = maze.TotalCells;
			var backtrack = new Direction [totalCells];
			int backtrackPosition = 0;

			int visited = 1;

			while (visited < totalCells) {

				var directions = GetAvailableDirections (maze, position);

				if (directions.Any ()) {

					var direction = GetRandomDirection (directions, random);
					var nextPosition = Maze.GetNextPosition (position, direction);

					RemoveWalls (position, nextPosition, direction, maze);

					backtrack [backtrackPosition] = direction;
					backtrackPosition++;

					position = nextPosition;

					visited++;
				} else {
					backtrackPosition--;
					position = Maze.GetPreviousPosition (position, backtrack [backtrackPosition]);
				}
			}

			return maze;
		}

	}
}
