using System;

namespace MazeCreator.Core
{
	[Flags]
	public enum CellInfo : byte
	{
		EmptyCell = 0,
		TopWall = 1 << 0,
		LeftWall = 1 << 1,
		BottomWall = 1 << 2,
		RightWall = 1 << 3,
		AllWalls = TopWall | LeftWall | BottomWall | RightWall,
		TopBorder = 1 << 4,
		LeftBorder = 1 << 5,
		BottomBorder = 1 << 6,
		RightBorder = 1 << 7,
		RemoveTopWall = ~TopWall & 0xFF,
		RemoveLeftWall = ~LeftWall & 0xFF,
		RemoveBottomWall = ~BottomWall & 0xFF,
		RemoveRightWall = ~RightWall & 0xFF,
	}
}
