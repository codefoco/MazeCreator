namespace MazeCreator.BoxDrawing
{
	public static class BoxDrawing
	{
		// 								 0    1    2    3    4    5   6     7    8    9   10   11   12   13   14   15
		static readonly char [] box = { ' ', '╶', '╵', '└', '╴', '─', '┘', '┴', '╷', '┌', '│', '├', '┐', '┬', '┤', '┼' };

		public static char CharFromFlags (BoxFlags flags)
		{
			var value = (byte)flags;
			return box [value];
		}
	}	
}		
