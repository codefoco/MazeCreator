/*
 * This file is part of MazeCreator.
 * 
 * Copyright (c)  2018 Vinicius Jarina (viniciusjarina@gmail.com)
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

using System.Diagnostics;

namespace MazeCreator.Core
{
	public class Maze
	{
		public int Columns {
			get;
		}

		public int Rows {
			get;
		}

		public int TotalCells {
			get {
				return Columns * Rows;
			}
		}

		readonly Cell [] cells;


		public Maze (int rows, int columns)
		{
			Columns = columns;
			Rows = rows;

			int totalCellWithEdge = (rows + 1) * (columns + 1);

			cells = new Cell [totalCellWithEdge];

			for (int i = 0; i < totalCellWithEdge; i++)
				cells [i] = new Cell (CellInfo.AllWalls);
			                                             
			for (int i = 0; i < Rows; i++) {
				int index = IndexFromPosition (new Position (i, 0));
				cells [index] = new Cell (cells [index].CellInfo | CellInfo.LeftBorder);

				index = IndexFromPosition (new Position (i, Columns - 1));
				cells [index] = new Cell (cells [index].CellInfo | CellInfo.RightBorder);
			}

			for (int i = 0; i < Columns; i++) {
				int index = IndexFromPosition (new Position (0, i));
				cells [index] = new Cell (cells [index].CellInfo | CellInfo.TopBorder);

				index = IndexFromPosition (new Position (Rows - 1, i));
				cells [index] = new Cell (cells [index].CellInfo | CellInfo.BottomBorder);
			}

			for (int i = 0; i <= Rows; i++) {
				int index = IndexFromPosition (new Position (i, Columns));
				cells[index] = Cell.EmptyCell;
			}

			for (int i = 0; i <= Columns; i++) {
				int index = IndexFromPosition (new Position (Rows, i));
				cells[index] = Cell.EmptyCell;
			}
		}

		int IndexFromPosition (Position position)
		{
			return Position.IndexFromPosition (position, Columns + 1);
		}

		public Cell this [int row, int column] {
			get {
				return this [new Position (row, column)];
			}
		}

		public Cell this[Position position] {
			get {
				int index = IndexFromPosition (position);
				return cells [index];
			}
			set {
				int index = IndexFromPosition (position);
				cells [index] = value;
			}
		}

		public void RemoveWalls (Position position, Position nextPosition, Direction direction)
		{
			Cell start  = this [position];
			Cell end    = this [nextPosition];

			start.RemoveStartWall (direction);
			end.RemoveEndWall (direction);

			this [position]     = start;
			this [nextPosition] = end;
		}
	}
}
