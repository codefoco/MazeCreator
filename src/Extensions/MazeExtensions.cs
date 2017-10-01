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
			Cell topRight = Cell.EmptyCell; ;
			Cell bottomLeft = Cell.EmptyCell; ;
			Cell bottomRight = Cell.EmptyCell; ;

			for (int row = 0; row <= maze.Rows; row++) {
				for (int column = 0; column <= maze.Columns; column++) {
					position.Row= row;
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


	}
}
