using System;

namespace MazeCreator
{
	[Flags]
	public enum BoxFlags : byte
	{
		None   = 0,
		Right  = 1 << 0,
		Top    = 1 << 1,
		Left   = 1 << 2,
		Bottom = 1 << 3,
	}
}
