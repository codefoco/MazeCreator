
namespace MazeCreator.Core
{
	public struct Position
	{
		public Position (int line, int column)
		{
			Line = line;
			Column = column;
		}

		public int Line {
			get; set;
		}

		public int Column {
			get; set;
		}

		public Position Up {
			get {
				return new Position (Line - 1, Column);
			}
		}

		public Position UpLeft {
			get {
				return new Position (Line - 1, Column - 1);
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

		public override bool Equals (object obj)
		{
			var position = obj as Position?;
			if (position == null)
				return false;
			return this == position;
		}

		public static bool operator == (Position lhs, Position rhs)
		{
			return lhs.Line == rhs.Line && lhs.Column == rhs.Column;
		}

		public static bool operator != (Position lhs, Position rhs)
		{
			return !(lhs == rhs);
		}

		public override int GetHashCode ()
		{
			return Line.GetHashCode () ^ Column.GetHashCode ();
		}

		public override string ToString ()
		{
			return string.Format ("[Position: Line={0}, Column={1}]", Line, Column);
		}
	}
}
