namespace MazeCreator
{
	public struct CellVisit
	{
		VisitInfo info;

		public CellVisit (VisitInfo info)
		{
			this.info = info;
		}

		public static CellVisit NotVisited {
			get {
				return new CellVisit (VisitInfo.NotVisited);
			}
		}

		public VisitInfo VisitInfo {
			get {
				return info;
			}
		}

		public bool Visited {
			get {
				
			}
			set {
				
			}
		}
	}
}
