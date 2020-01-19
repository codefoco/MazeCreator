/*
 * This file is part of MazeCreator.
 * 
 * Copyright (c)  2020 Vinicius Jarina (viniciusjarina@gmail.com)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */


using System;
using System.Collections.Generic;
using System.Linq;

using MazeCreator.Core;
using MazeCreator.Extensions;

namespace MazeCreator
{
	public class DefaultSolver : IMazeSolver
	{
		public IRandomGenerator Random { get; set; }

		public Action<Maze, Position> PositionVisited { get; set; }
		public Action<Maze, Position> WalkBack { get; set; }

		public Direction [] Solve (Maze maze, Position start, Position end)
		{
			var backtrack = new Direction [maze.TotalCells];
			int backtrackPosition = 0;

			Position position = start;

			CellVisitBuffer buffer = new CellVisitBuffer (maze.Rows, maze.Columns);

			while (position != end) {

				Direction [] directions = GetAvailableDirections (buffer, maze, position);

				if (directions.Any ()) {

					Direction direction = GetRandomDirection (directions);
					Position nextPosition = Position.GetNextPosition (position, direction);

					backtrack [backtrackPosition] = direction;
					backtrackPosition++;

					buffer.WalkPath (position, nextPosition, direction);
					position = nextPosition;

					if (PositionVisited != null)
						PositionVisited (maze, position);

				} else {
					backtrackPosition--;
					Direction direction = backtrack [backtrackPosition].Oposite ();

					if (WalkBack != null)
						WalkBack (maze, position);

					Position nextPosition = Position.GetNextPosition (position, direction);
					buffer.WalkBackPath (position, nextPosition, direction);
					position = nextPosition;
				}
			}
			var result = new Direction [backtrackPosition];
			Array.Copy (backtrack, result, backtrackPosition);
			return result;
		}

		Direction GetRandomDirection (Direction [] directions)
		{
			if (directions.Length == 1)
				return directions [0];
			return directions [Random.Next (directions.Length)];
		}


		static Direction [] GetAvailableDirections (CellVisitBuffer buffer, Maze maze, Position position)
		{
			var directions = new List<Direction> (4);

			if (CanGoUp (position, buffer, maze))
				directions.Add (Direction.Up);
			if (CanGoLeft (position, buffer, maze))
				directions.Add (Direction.Left);
			if (CanGoDown (position, buffer, maze))
				directions.Add (Direction.Down);
			if (CanGoRight (position, buffer, maze))
				directions.Add (Direction.Right);

			return directions.ToArray ();
		}

		static bool CanGoUp (Position position, CellVisitBuffer buffer, Maze maze)
		{
			CellVisit visitCell = buffer [position.Up];
			Cell cell = maze [position];
			return !cell.HasTopWall && !visitCell.Visited;
		}

		static bool CanGoLeft (Position position, CellVisitBuffer buffer, Maze maze)
		{
			CellVisit visitCell = buffer [position.Left];
			Cell cell = maze [position];
			return !cell.HasLeftWall && !visitCell.Visited;
		}

		static bool CanGoDown (Position position, CellVisitBuffer buffer, Maze maze)
		{
			CellVisit visitCell = buffer [position.Down];
			Cell cell = maze [position];
			return !cell.HasBottomWall && !visitCell.Visited;
		}

		static bool CanGoRight (Position position, CellVisitBuffer buffer, Maze maze)
		{
			CellVisit visitCell = buffer [position.Right];
			Cell cell = maze [position];
			return !cell.HasRightWall && !visitCell.Visited;
		}

	}
}
