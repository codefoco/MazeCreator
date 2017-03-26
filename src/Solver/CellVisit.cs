using MazeCreator.Core;

namespace MazeCreator
{
	public struct CellVisit
	{
		VisitInfo info;

		readonly static VisitInfo [] visitWallFlagsStart = {
			VisitInfo.CellBottomPath,
			VisitInfo.CellLeftPath,
			VisitInfo.CellTopPath,
			VisitInfo.CellBottomPath,
		};

		readonly static VisitInfo [] visitWallFlagsEnd = {
			VisitInfo.TopPath,
			VisitInfo.RightPath,
			VisitInfo.BottomPath,
			VisitInfo.LeftPath,
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

		public void MarkStartCell (Direction direction)
		{
			info |= visitWallFlagsStart [(int)direction];
		}

		public void MarkEndCell (Direction direction)
		{
			info |= visitWallFlagsEnd [(int)direction];
		}


	}
}
