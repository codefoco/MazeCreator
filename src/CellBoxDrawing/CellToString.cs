using MazeCreator.BoxDrawing;
using MazeCreator.Core;

namespace MazeCreator.CellBoxDrawing
{
	public static class CellToString
	{
		public static char [] GetCellString (Cell topLeft, Cell topRight, Cell bottomLeft, Cell bottomRight)
		{
			char [] chars = new char [2];

			BoxFlags flags = BoxFlags.None;

			if (topRight.HasBottomWall || bottomRight.HasTopWall)
				flags |= BoxFlags.Right;
			if (topLeft.HasRightWall || topRight.HasLeftWall)
				flags |= BoxFlags.Top;
			if (topLeft.HasBottomWall || bottomLeft.HasTopWall)
				flags |= BoxFlags.Left;
			if (bottomLeft.HasRightWall || bottomRight.HasLeftWall)
				flags |= BoxFlags.Bottom;

			chars [0] = ConvertFlags.CharFromFlags (flags);

			flags = BoxFlags.None;

			if (topRight.HasBottomWall || bottomRight.HasTopWall)
				flags |= BoxFlags.Right | BoxFlags.Left;

			chars [1] = ConvertFlags.CharFromFlags (flags);
			return chars;
		}
	}
}
