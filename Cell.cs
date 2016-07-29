
using System;

namespace MazeCreator
{
	[Flags]
	public enum CellInfo : byte
	{
		TopWall      = 1 << 0,
		LeftWall     = 1 << 1,
		BottomWall   = 1 << 2,
		RightWall    = 1 << 3,
		AllWalls     = TopWall | LeftWall | BottomWall | RightWall,
		TopBorder    = 1 << 4,
		LeftBorder   = 1 << 5,
		BottomBorder = 1 << 6,
		RightBorder  = 1 << 7,
		InvalidCell  = TopBorder | LeftBorder | BottomBorder | RightBorder,
		RemoveTopWall    = ~TopWall     & 0xFF,
		RemoveLeftWall   = ~LeftWall    & 0xFF,
		RemoveBottomWall = ~BottomWall  & 0xFF,
		RemoveRightWall  = ~RightWall   & 0xFF,
	}

	public enum Direction : byte
	{
		Up,
		Left,
		Down,
		Right,
	}

	public struct Cell
	{
		CellInfo info;

		readonly static CellInfo [] removeWallFlagsStart = {
			CellInfo.RemoveTopWall,
			CellInfo.RemoveLeftWall,
			CellInfo.RemoveBottomWall,
			CellInfo.RemoveRightWall,
		};

		readonly static CellInfo [] removeWallFlagsEnd = {
			CellInfo.RemoveBottomWall,
			CellInfo.RemoveRightWall,
			CellInfo.RemoveTopWall,
			CellInfo.RemoveLeftWall,
		};

		public Cell (CellInfo info)
		{
			this.info = info;
		}

		public static Cell InvalidCell {
			get {
				return new Cell (CellInfo.InvalidCell);
			}
		}

		public CellInfo CellInfo {
			get {
				return info;
			}
		}

		public bool HasLeftBorder {
			get {
				return (info & CellInfo.LeftBorder) == CellInfo.LeftBorder;
			}
		}

		public bool HasTopBorder {
			get {
				return (info & CellInfo.TopBorder) == CellInfo.TopBorder;
			}
		}

		public bool HasBottomBorder {
			get {
				return (info & CellInfo.BottomBorder) == CellInfo.BottomBorder;
			}
		}

		public bool HasRightBorder {
			get {
				return (info & CellInfo.RightBorder) == CellInfo.RightBorder;
			}
		}

		public bool HasAllWalls {
			get {
				return (info & CellInfo.AllWalls) == CellInfo.AllWalls;
			}
		}

		public void RemoveStartWall (Direction direction)
		{
			info &= removeWallFlagsStart [(int)direction];
		}

		public void RemoveEndWall (Direction direction)
		{
			info &= removeWallFlagsEnd [(int)direction];
		}

	}
}
