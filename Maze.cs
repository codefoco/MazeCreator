using System.Text;

namespace MazeCreator
{
	public class Maze
	{
		public int Columns {
			get;
		}

		public int Lines {
			get;
		}

		public int TotalCells {
			get {
				return Columns * Lines;
			}
		}

		readonly Cell [] cells;

		public Maze (int lines, int columns)
		{
			Columns = columns;
			Lines = lines;

			cells = new Cell [lines * columns];
			for (int i = 0; i < TotalCells; i++)
				cells [i] = new Cell (CellInfo.AllWalls);
			                                             
			for (int i = 0; i < Lines; i++) {
				int index = IndexFromPosition (new Position (i, 0));
				cells [index] = new Cell (CellInfo.AllWalls | CellInfo.LeftBorder);

				index = IndexFromPosition (new Position (i, Columns - 1));
				cells [index] = new Cell (CellInfo.AllWalls | CellInfo.RightBorder);
			}

			for (int i = 0; i < Columns; i++) {
				int index = IndexFromPosition (new Position (0, i));
				cells [index] = new Cell (CellInfo.AllWalls | CellInfo.TopBorder);

				index = IndexFromPosition (new Position (Lines - 1, i));
				cells [index] = new Cell (CellInfo.AllWalls | CellInfo.BottomBorder);
			}
		}

		public static Position GetNextPosition (Position position, Direction direction)
		{
			switch (direction) {
				case Direction.Up:
					return new Position (position.Line - 1, position.Column);
				case Direction.Left:
					return new Position (position.Line, position.Column - 1);
				case Direction.Down:
					return new Position (position.Line + 1, position.Column);
				case Direction.Right:
					return new Position (position.Line, position.Column + 1);
				}
			return position;
		}

		public static Position GetPreviousPosition (Position position, Direction direction)
		{
			switch (direction) {
			case Direction.Up:
				return new Position (position.Line + 1, position.Column);
			case Direction.Left:
				return new Position (position.Line, position.Column + 1);
			case Direction.Down:
				return new Position (position.Line - 1, position.Column);
			case Direction.Right:
				return new Position (position.Line, position.Column - 1);
			}
			return position;
		}

		int IndexFromPosition (Position position)
		{
			return Columns * position.Line + position.Column;
		}

		bool IsValidPosition (Position position)
		{
			return 0 <= position.Line && position.Line < Lines &&
				   0 <= position.Column && position.Column < Columns;
		}


		public Cell this[Position position] {
			get {
				if (!IsValidPosition (position))
					return Cell.EmptyCell;
				
				int index = IndexFromPosition (position);
				return cells [index];
			}
			set {
				if (!IsValidPosition (position))
					return;
				
				int index = IndexFromPosition (position);
				cells [index] = value;
			}
		}

		public override string ToString ()
		{
			Position position = new Position (0, 0);
			var builder = new StringBuilder ();

			Cell topLeft  = Cell.EmptyCell;
			Cell topRight = Cell.EmptyCell;;
			Cell bottomLeft = Cell.EmptyCell;;
			Cell bottomRight = Cell.EmptyCell;;

			for (int line = 0; line <= Lines; line++) {
				for (int column = 0; column <= Columns; column++) {
					position.Line = line;
					position.Column = column;

					topLeft = this [position.UpLeft];
					topRight = this [position.Up];
					bottomLeft = this [position.Left];
					bottomRight = this [position];
					builder.Append (Cell.GetCellString (topLeft, topRight, bottomLeft, bottomRight));
				}
				builder.AppendLine ();
			}
			
			return builder.ToString ();
		}
	}
}
