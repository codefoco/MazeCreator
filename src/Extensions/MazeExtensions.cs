using System.Text;

using MazeCreator.Core;
using MazeCreator.CellBoxDrawing;
using System;

namespace MazeCreator.Extensions
{
	public static class MazeExtensions
	{
		public static string ToBoxString (this Maze maze)
		{
			Position position = new Position (0, 0);
			var builder = new StringBuilder ();

			Cell topLeft = Cell.EmptyCell;
			Cell topRight = Cell.EmptyCell;
			Cell bottomLeft = Cell.EmptyCell;
			Cell bottomRight = Cell.EmptyCell;

			for (int row = 0; row <= maze.Rows; row++) {
				for (int column = 0; column <= maze.Columns; column++) {
					position.Row    = row;
					position.Column = column;

					topLeft = maze [position.UpLeft];
					topRight = maze [position.Up];
					bottomLeft = maze [position.Left];
					bottomRight = maze [position];
					builder.Append (CellToString.GetCellString (topLeft, topRight, bottomLeft, bottomRight));
				}
				builder.AppendLine ();
			}

			return builder.ToString ();
		}

		public static void PostProcessCellWalls (this Maze maze)
		{
			int rows = maze.Rows;
			int columns = maze.Columns;

			for (int row = 0; row < rows; row++) {
				for (int column = 0; column < columns; column++) {

					Position position = new Position (row, column);
					Cell cell = maze [position];

					cell.CellInfo = cell.CellInfo | ~(CellInfo.RightBorder & CellInfo.TopBorder & CellInfo.LeftBorder & CellInfo.BottomBorder);
					Cell upCell = maze [position.Up];
					Cell leftCell = maze [position.Left];
					Cell downCell = maze [position.Down];
					Cell rightCell = maze [position.Right];

					if (cell.HasTopWall || cell.HasLeftWall || leftCell.HasTopWall || upCell.HasLeftWall)
						cell.CellInfo &= CellInfo.TopBorder;
					
					if (cell.HasTopWall || cell.HasRightWall || rightCell.HasTopWall || upCell.HasRightWall)
						cell.CellInfo &= CellInfo.RightBorder;
					
					if (cell.HasBottomWall || cell.HasLeftWall || leftCell.HasBottomWall || downCell.HasLeftWall)
						cell.CellInfo &= CellInfo.BottomBorder;
					
					if (cell.HasBottomWall || cell.HasRightWall || rightCell.HasBottomWall || downCell.HasRightWall)
						cell.CellInfo &= CellInfo.LeftBorder;

					maze [position] = cell;
				}
			}
		}


	}
}
