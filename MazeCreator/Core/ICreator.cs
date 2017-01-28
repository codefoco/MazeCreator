namespace MazeCreator.Core
{
	public interface ICreator
	{
		Maze Create (int lines, int columns, IRandomGenerator random);
	}
}
