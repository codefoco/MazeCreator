using MazeCreator.Core;

namespace MazeCreator
{
	public struct CellVisit
	{
		VisitInfo info;

		readonly static VisitInfo [] visitPathFlags = {
			VisitInfo.TopPath,
			VisitInfo.LeftPath,
			VisitInfo.BottomPath,
			VisitInfo.RightPath,
		};


		readonly static VisitInfo [] visitBackPathFlags = {
			VisitInfo.TopBack,
			VisitInfo.LeftBack,
			VisitInfo.BottomBack,
			VisitInfo.RightBack,
		};


		public CellVisit (VisitInfo info)
		{
			this.info = info;
		}

		public static CellVisit NotVisitedCell {
			get {
				return new CellVisit (VisitInfo.NotVisited);
			}
		}

		public static CellVisit VisitedCell {
			get {
				return new CellVisit (VisitInfo.Visited);
			}
		}

		public bool Visited {
			get {
				return (info & VisitInfo.Visited) == VisitInfo.Visited;
			}
		}

		public VisitInfo VisitInfo {
			get {
				return info;
			}
		}

		public void MarkStartCellPath (Direction direction)
		{
			info |= visitPathFlags [(int)direction] | VisitInfo.Visited;
		}

		public void MarkEndCellPath (Direction direction)
		{
			info |= visitPathFlags [(int)direction];
		}

		public void MarkStartCellBackPath (Direction direction)
		{
			VisitInfo flag = visitPathFlags [(int)direction];
			info &= ~flag;
			info |= visitBackPathFlags [(int)direction] | VisitInfo.Visited;
		}

		public void MarkEndCellBackPath (Direction direction)
		{
			info &= ~(visitPathFlags[(int)direction]);
			info |= visitBackPathFlags [(int)direction];
		}
	}
}
