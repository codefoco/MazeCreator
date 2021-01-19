/*
 * This file is part of MazeCreator.
 * 
 * Copyright (c)  2021 Vinicius Jarina (viniciusjarina@gmail.com)
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

using MazeCreator.Core;
using MazeCreator.Extensions;

namespace MazeCreator.Creator
{
	public class Kruskal : ICreator
	{
		public IRandomGenerator Random { get; set; }
		
		public Action<Maze, Position> PositionVisited { get; set; }
		public Action<Maze, Position, Direction> WallRemoved { get; set; }

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

		public Maze Create (int rows, int columns)
		{
			Maze maze = new Maze (rows, columns);
			int totalCells = maze.TotalCells;
			unionFind = new int [totalCells];

			var walls = new PositionDirection [(totalCells * 2) - columns - rows];
			int wallIndex = 0;
			int index = 0;
			int visited = 1;
			int root1 = 0;
			int root2 = 0;

			Position start = new Position (0, 0);
			Position end   = new Position (0, 0);

			for (int i = 0; i < columns; i++) {
				for (int j = 0; j < rows; j++) {
					
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
				
				index = Random.Next (wallIndex--);

				start = walls [index].Position;
				Direction direction = walls [index].Direction;

				if (index != wallIndex)
					walls [index] = walls [wallIndex];
				
				if (direction == Direction.Up)
					end = start.Up;
				else
					end = start.Left;
				
				root1 = Find (Position.IndexFromPosition (start, maze.Columns));
				root2 = Find (Position.IndexFromPosition (end, maze.Columns));

				if (root1 != root2) {
					
					Union (root1, root2);
					visited++;

					if (direction == Direction.Up)
						maze.RemoveWalls (start, Direction.Up);
					else
						maze.RemoveWalls (start, Direction.Left);
				}
			}
			maze.PostProcessCellWalls ();
			return maze;
		}
	}
}
