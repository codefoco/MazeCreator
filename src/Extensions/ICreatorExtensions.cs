using System.Threading.Tasks;

using MazeCreator.Core;

namespace MazeCreator.Extensions
{
	public static class ICreatorExtensions
	{
		public static Task<Maze> CreateAsync (this ICreator creator, int lines, int columns)
		{
			return Task.Run (() => creator.Create (lines, columns));
		}
	}
}
