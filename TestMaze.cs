using NUnit.Framework;
using MazeCreator;

using System;


namespace MazeCreatorTest
{
	public class TestRandomGenerator : IRandomGenerator
	{
		Random random = new Random (37);

		public int Next (int max)
		{
			return random.Next (max);
		}
	}
	[TestFixture]
	public class Test
	{
		[Test]
		public void TestDFS ()
		{
			var random = new TestRandomGenerator ();
			var result = Creator.Create (10, 10, Algorithm.DFS, random);
			string s = result.ToString();
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
