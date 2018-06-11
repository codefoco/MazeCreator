using System.Text;

using MazeCreator.Core;
using MazeCreator.CellBoxDrawing;

namespace MazeCreator.Extensions
{
	public static class MazeExtensions
	{
		public static string ToBoxString (this Maze maze)
		{
			var builder = new StringBuilder ();
			var position = new Position();
			for (int row = 0; row <= maze.Rows; row++) {
				for (int column = 0; column <= maze.Columns; column++) {
					position.Row = row;
					position.Column = column;
					Cell cell = Cell.EmptyCell;

					if (column < maze.Columns && row < maze.Rows)
						cell = maze[position];
					else
						cell = maze.ProcessCell(position, cell);

					builder.Append (CellToString.GetCellString (cell));
				}
				builder.AppendLine ();
			}

			return builder.ToString ();
		}

		public static Cell ProcessCell (this Maze maze, Position position, Cell cell)
		{
			cell.CellInfo = cell.CellInfo & CellInfo.RemoveBorders;

			Cell upLeftCell = Cell.EmptyCell;
			Cell upCell = Cell.EmptyCell;
			Cell leftCell = Cell.EmptyCell;

			if (position.Row > 0 && position.Column > 0)
				upLeftCell = maze[position.UpLeft];
			if (position.Row > 0 && position.Column < maze.Columns)
				upCell = maze[position.Up];
			if (position.Column > 0 && position.Row < maze.Rows)
				leftCell = maze[position.Left];

			if (upCell.HasBottomWall)
				cell.CellInfo |= CellInfo.TopWall;

			if (leftCell.HasRightWall)
				cell.CellInfo |= CellInfo.LeftWall;

			if (upLeftCell.HasRightWall || upCell.HasLeftWall)
				cell.CellInfo |= CellInfo.UpLeftCellRightWall;

			if (upLeftCell.HasBottomWall || leftCell.HasTopWall)
				cell.CellInfo |= CellInfo.UpLeftCellBottomWall;

			return cell;
		}

		public static void PostProcessCellWalls (this Maze maze)
		{
			int rows = maze.Rows;
			int columns = maze.Columns;

			for (int row = 0; row < rows; row++) {
				for (int column = 0; column < columns; column++) {

					Position position = new Position(row, column);
					maze[position] = maze.ProcessCell(position, maze[position]);
				}
			}
		}


	}
}
