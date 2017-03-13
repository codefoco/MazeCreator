using System;
namespace MazeCreator
{
	[Flags]
	public enum VisitInfo : short
	{
		NotVisited = 0,
		TopPath    = 1 << 0,
		LeftPath   = 1 << 1,
		BottomPath = 1 << 2,
		RightPath  = 1 << 3,
		CellPath   = 1 << 4,

		CellTopPath    = CellPath | TopPath,
		CellLeftPath   = CellPath | LeftPath,
		CellBottomPath = CellPath | BottomPath,
		CellRightPath  = CellPath | RightPath,

		TopBack    = 1 << 5,
		LeftBack   = 1 << 6,
		BottomBack = 1 << 7,
		RightBack  = 1 << 8,
		CellBack   = 1 << 9,

		CellTopBack    = CellBack | TopBack,
		CellLeftBack   = CellBack | LeftBack,
		CellBottomBack = CellBack | BottomBack,
		CellRightBack  = CellBack | RightBack,
	}
}
