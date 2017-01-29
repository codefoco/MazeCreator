using System;

using MazeCreator.Core;

namespace MazeCreator.Creator
{
	struct PositionDirection
	{
		public Position Position {
			get;
			set;
		}
		public Direction Direction {
			get;
			set;
		}
	}

	public class Kruskal : ICreator
	{
		int [] unionFind;

		int Find (int n)
		{
			if (unionFind [n] < 0)
				return n;
			return unionFind [n] = Find (unionFind [n]);
		}

		void Union (int r1, int r2)
		{
			if (unionFind [r1] <= unionFind [r2]) {
				unionFind [r1] += unionFind [r2];
				unionFind [r2] = r1;
			} else {
				unionFind [r2] += unionFind [r1];
				unionFind [r1] = r2;
			}
		}

		public Maze Create (int lines, int columns, IRandomGenerator random)
		{
			Maze maze = new Maze (lines, columns);
			int totalCells = maze.TotalCells;
			unionFind = new int [totalCells];

			var walls = new PositionDirection [(totalCells * 2) - columns - lines];
			int wallIndex = 0;
			int index = 0;
			int visited = 1;
			int root1 = 0;
			int root2 = 0;

			Position start = new Position (0, 0);
			Position end   = new Position (0, 0);

			for (int i = 0; i < columns; i++) {
				for (int j = 0; j < lines; j++) {
					
					unionFind [(j * columns) + i] = -1;

					if (i != 0) {
						walls [wallIndex].Position = new Position (j, i);
						walls [wallIndex].Direction = Direction.Left;
						wallIndex++;
					}

					if (j != 0) {
						walls [wallIndex].Position = new Position (j, i);
						walls [wallIndex].Direction = Direction.Up;
						wallIndex++;
					}
				}
			}

			while (visited < totalCells) {
				
				index = random.Next (wallIndex--);

				start = walls [index].Position;
				Direction direction = walls [index].Direction;

				if (index != wallIndex)
					walls [index] = walls [wallIndex];
				
				if (direction == Direction.Up)
					end = start.Up;
				else
					end = start.Left;
				
				root1 = Find (maze.IndexFromPosition (start));
				root2 = Find (maze.IndexFromPosition (end));

				if (root1 != root2) {
					
					Union (root1, root2);
					visited++;

					if (direction == Direction.Up)
						maze.RemoveWalls (start, end, Direction.Up);
					else
						maze.RemoveWalls (start, end, Direction.Left);
				}
			}
			return maze;
		}
	}
}
