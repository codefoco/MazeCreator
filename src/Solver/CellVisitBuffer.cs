using MazeCreator.Core;
using MazeCreator.Extensions;

namespace MazeCreator
{
	public class CellVisitBuffer
	{
		public int Columns {
			get;
		}

		public int Rows {
			get;
		}

		public int TotalCells {
			get {
				return Columns * Rows;
			}
		}

		readonly CellVisit [] cells;


		public CellVisitBuffer (int rows, int columns)
		{
			Columns = columns;
			Rows = rows;

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
			return 0 <= position.Row && position.Row < Rows &&
				   0 <= position.Column && position.Column < Columns;
		}

		public CellVisit this [int row, int column] {
			get {
				return this [new Position (row, column)];
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

			start.MarkStartCellPath (direction.Oposite ());
			end.MarkEndCellPath (direction);

			this [position] = start;
			this [nextPosition] = end;
		}

		public void WalkBackPath (Position position, Position nextPosition, Direction direction)
		{
			CellVisit start = this [position];
			CellVisit end = this [nextPosition];

			start.MarkStartCellBackPath (direction.Oposite ());
			end.MarkEndCellBackPath (direction);

			this [position] = start;
			this [nextPosition] = end;
		}
	}
}
