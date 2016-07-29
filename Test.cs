using NUnit.Framework;
using MazeCreator;

namespace MazeCreatorTest
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void TestDFS ()
		{
			var result = Creator.Create (30, 20);
		}
	}
}
