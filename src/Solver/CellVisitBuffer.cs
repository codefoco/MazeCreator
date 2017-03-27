using MazeCreator.Core;

namespace MazeCreator
{
	public class CellVisitBuffer
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

		readonly CellVisit [] cells;


		public CellVisitBuffer (int lines, int columns)
		{
			Columns = columns;
			Lines = lines;

			cells = new CellVisit [TotalCells];
			for (int i = 0; i < TotalCells; i++)
				cells [i] = new CellVisit (VisitInfo.NotVisited);
		}

		int IndexFromPosition (Position position)
		{
			return Position.IndexFromPosition (position, Columns);
		}

		bool IsValidPosition (Position position)
		{
			return 0 <= position.Line && position.Line < Lines &&
				   0 <= position.Column && position.Column < Columns;
		}

		public CellVisit this [int line, int column] {
			get {
				return this [new Position (line, column)];
			}
		}

		public CellVisit this [Position position] {
			get {
				if (!IsValidPosition (position))
					return CellVisit.NotVisitedCell;

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

		public void WalkPath (Position position, Position nextPosition, Direction direction)
		{
			CellVisit start = this [position];
			CellVisit end = this [nextPosition];

			start.MarkStartCell (direction);
			end.MarkEndCell (direction);

			this [position] = start;
			this [nextPosition] = end;
		}
	}
}
