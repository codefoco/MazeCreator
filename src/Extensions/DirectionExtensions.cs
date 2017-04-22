using MazeCreator.Core;

namespace MazeCreator.Extensions
{
    public static class DirectionExtensions
    {
		public static Direction Oposite (this Direction direction)
		{
			return (Direction)((((byte)direction) + 2) & 3); ;
		}
    }
}
