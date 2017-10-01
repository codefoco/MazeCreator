using System.Threading.Tasks;

using MazeCreator.Core;

namespace MazeCreator.Extensions
{
	public static class ICreatorExtensions
	{
		public static Task<Maze> CreateAsync (this ICreator creator, int rows, int columns)
		{
			return Task.Run (() => creator.Create (rows, columns));
		}
	}
}
