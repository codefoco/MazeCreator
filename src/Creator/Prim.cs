/*
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

namespace MazeCreator.Creator
{
	
	public class Prim : ICreator
	{
		public IRandomGenerator Random { get; set; }
		
		public Action<Maze, Position> PositionVisited { get; set; }
		public Action<Maze, Position, Position, Direction> WallRemoved { get; set; }

		void MoveCell (List<Position> from, List<Position> to, int index)
		{
			if (index == -1)
				return;
			
			to.Add (from [index]);
			from.RemoveAt (index);
		}

		public Maze Create (int rows, int columns)
		{
			Maze maze = new Maze (rows, columns);

			int totalCells = maze.TotalCells;

			var output   = new List<Position> (totalCells);
			var frontier = new List<Position> (totalCells);
			var input    = new List<Position> (totalCells);

			Position position;
			Position upCell    = new Position (0, 0);
			Position downCell  = new Position (0, 0);
			Position rightCell = new Position (0, 0);
			Position leftCell  = new Position (0, 0);

			Direction [] directions = new Direction [4];

			int index = 0;
			int candidates = 0;

			for (int i = 0; i < columns; i++) {
				for (int j = 0; j < rows; j++) {
					output.Add (new Position (i, j));
				}
			}
			
			index = Random.Next (totalCells);
			position  = output [index];

			MoveCell (output, input, index);

			if (position.Column > 0)
				MoveCell (output, frontier, output.IndexOf (new Position (position.Row, position.Column - 1)));
			
			if (position.Row > 0)
				MoveCell (output, frontier, output.IndexOf (new Position (position.Row - 1, position.Column)));
			
			if (position.Column < (columns - 1))
				MoveCell (output, frontier, output.IndexOf (new Position (position.Row, position.Column + 1)));
			
			if (position.Row < (rows - 1))
				MoveCell (output, frontier, output.IndexOf (new Position (position.Row + 1, position.Column)));

			while (frontier.Any ()) {
				
				index = Random.Next (frontier.Count);
				position  = frontier [index];

				MoveCell (frontier, input, index);

				if (position.Column > 0) {
					leftCell.Column = position.Column - 1;
					leftCell.Row   = position.Row;
					MoveCell (output, frontier, output.IndexOf (leftCell));
				}

				if (position.Row > 0) {
					upCell.Column = position.Column;
					upCell.Row   = position.Row - 1;
					MoveCell (output, frontier, output.IndexOf (upCell));
				}

				if (position.Column < (columns - 1)) {
					rightCell.Column = position.Column + 1;
					rightCell.Row   = position.Row;
					MoveCell (output, frontier, output.IndexOf (rightCell));
				}

				if (position.Row < (rows - 1)) {
					downCell.Column = position.Column; 
					downCell.Row   = position.Row + 1;
					MoveCell (output, frontier, output.IndexOf (downCell));
				}

				candidates = 0;

				if (position.Column > 0 && input.IndexOf (leftCell) >= 0)
					directions [candidates++] = Direction.Left;
				
				if (position.Row > 0 && input.IndexOf (upCell) >= 0)
					directions [candidates++] = Direction.Up;
				
				if (position.Column < (columns - 1) && input.IndexOf (rightCell) >= 0)
					directions [candidates++] = Direction.Right;
				
				if (position.Row < (rows - 1) && input.IndexOf (downCell) >= 0)
					directions [candidates++] = Direction.Down;
				
				Direction direction = directions [Random.Next (candidates)];

				var nextPosition = Position.GetNextPosition (position, direction);
				maze.RemoveWalls (position, nextPosition, direction);
			}

			return maze;
		}
	}
}
