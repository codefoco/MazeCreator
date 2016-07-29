using System;

namespace MazeCreator
{
	public struct Position
	{
		public Position (int line, int column)
		{
			Line = line;
			Column = column;
		}

		public int Line {
			get;
		}

		public int Column {
			get;
		}

		public Position Up {
			get {
				return new Position (Line - 1, Column);
			}
		}

		public Position Left {
			get {
				return new Position (Line, Column - 1);
			}
		}

		public Position Down {
			get {
				return new Position (Line + 1, Column);
			}
		}

		public Position Right {
			get {
				return new Position (Line, Column + 1);
			}
		}

		public static Position RandomPosition (int maxLine, int maxColumn, IRandomGenerator random)
		{
			int line = random.Next (maxLine);
			int column = random.Next (maxColumn);
			return new Position (line, column);
		}
	}
}
