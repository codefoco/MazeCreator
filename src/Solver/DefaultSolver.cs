﻿/*
 * This file is part of MazeCreator.
 * 
 * Copyright (c) 2017 Vinicius Jarina (viniciusjarina@gmail.com)
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

namespace MazeCreator
{
	public class DefaultSolver : IMazeSolver
	{
		IRandomGenerator Random { get; set; }

		Action<Maze, Position> PositionVisited { get; set; }
		Action<Maze, Position> WalkBack { get; set; }

		public PositionDirection [] Solve (Maze maze, Position start, Position end)
		{
			var backtrack = new Direction [mazeToSolve.TotalCells];
			int backtrackPosition = 0;
			Position currentPosition = start;
			var steps = new List<PositionDirection> ();

			CellVisitBuffer buffer = new CellVisitBuffer (maze.Lines, maze.Columns);

			buffer [start].Visit ();

			while (currentPosition != end) {
				if (CanGoUp (currentPosition, buffer, maze))
			}
		

			return steps.ToArray ();
		}

		static Direction GetRandomDirection (Direction [] directions, IRandomGenerator random)
		{
			if (directions.Length == 1)
				return directions [0];
			return directions [random.Next (directions.Length)];
		}


		static Direction [] GetAvailableDirections (CellVisitBuffer buffer, Position position)
		{
			var directions = new List<Direction> (4);

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

		static bool CanGoUp (Position position, CellVisitBuffer buffer, Maze maze)
		{
			CellVisit cell = buffer [position];
			return !cell.HasTopWall && !buffer [position.Up].Visited;
		}

		static bool CanGoLeft (Position position, CellVisitBuffer buffer)
		{
			CellVisit cell = buffer [position];
			return !cell.HasLeftWall && !maze [position.Left].Visited;
		}

		static bool CanGoDown (Position position, CellVisitBuffer buffer)
		{
			CellVisit cell = buffer [position];
			return !cell.HasBottomWall && !maze [position.Down].Visited;
		}

		static bool CanGoRight (Position position, CellVisitBuffer buffer)
		{
			CellVisit cell = buffer [position];
			return !cell.HasRightWall && !maze [position.Down].Visited;
		}

	}
}