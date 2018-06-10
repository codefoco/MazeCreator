using MazeCreator.BoxDrawing;
using MazeCreator.Core;

namespace MazeCreator.CellBoxDrawing
{
	public static class CellToString
	{
		public static char [] GetCellString (Cell cell)
		{
			char [] chars = new char [2];

			BoxFlags flags = BoxFlags.None;

			if (cell.HasTopWall)
				flags |= BoxFlags.Right;
			if (cell.HasUpLeftRightWall)
				flags |= BoxFlags.Top;
			if (cell.HasUpLeftBottomWall)
				flags |= BoxFlags.Left;
			if (cell.HasLeftWall)
				flags |= BoxFlags.Bottom;

			chars [0] = ConvertFlags.CharFromFlags (flags);

			flags = BoxFlags.None;

			if (cell.HasTopWall)
				flags |= BoxFlags.Right | BoxFlags.Left;

			chars [1] = ConvertFlags.CharFromFlags (flags);
			return chars;
		}
	}
}
