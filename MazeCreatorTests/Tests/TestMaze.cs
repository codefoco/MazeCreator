using NUnit.Framework;

using MazeCreator.Core;
using MazeCreator.Extensions;

namespace MazeCreatorTest.Tests
{
	[TestFixture]
	public class CreatorTests
	{
		[Test]
		public void DFS ()
		{
			var random = new TestRandomGenerator ();
			Maze maze = Creator.Create (10, 10, Algorithm.DFS, random);
			string s = maze.ToBoxString();

			string expected =
@"┌───────────┬─┬─┬───┐ 
│ ┌───┬─╴ ╷ │ │ ╵ ╷ │ 
├─┘ ╷ ╵ ┌─┤ │ └───┤ │ 
│ ┌─┴───┘ ╵ ├─┬─╴ │ │ 
│ └─┐ ╶─┬───┤ │ ╶─┘ │ 
│ ╷ └─┐ ╵ ╷ ╵ └───┐ │ 
├─┴─╴ │ ┌─┴───┬───┘ │ 
│ ╶───┤ │ ╶─┐ │ ╶───┤ 
│ ┌─╴ ├─┴─┐ │ └───┐ │ 
│ │ ╶─┘ ╷ ╵ └─┐ ╶─┘ │ 
└─┴─────┴─────┴─────┘ 
";
			Assert.AreEqual (expected, s);
		}
	}
}
