using System.Text;

using MazeCreator.Core;
using MazeCreator.CellBoxDrawing;

namespace MazeCreator.Extensions
{
	public static class MazeExtensions
	{
		public static string ToBoxString (this Maze maze)
		{
			Position position = new Position (0, 0);
			var builder = new StringBuilder ();

			for (int row = 0; row <= maze.Rows + 1; row++) {
				for (int column = 0; column <= maze.Columns + 1; column++) {
					position.Row    = row;
					position.Column = column;
					Cell cell = maze [position];
					builder.Append (CellToString.GetCellString (cell));
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

					cell.CellInfo = cell.CellInfo & CellInfo.RemoveBorders;

					Cell upLeftCell = maze[position.UpLeft];
					Cell upCell = maze[position.Up];
					Cell leftCell = maze [position.Left];

					if (upLeftCell.HasRightWall ||  upCell.HasLeftWall)
						cell.CellInfo |= CellInfo.UpLeftCellRightWall;
					
					if (upLeftCell.HasBottomWall || leftCell.HasTopWall)
						cell.CellInfo |= CellInfo.UpLeftCellBottomWall;
					
					maze [position] = cell;
				}
			}
		}


	}
}
