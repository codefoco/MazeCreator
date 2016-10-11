using NUnit.Framework;
using MazeCreator;

using System;


namespace MazeCreatorTest
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void TestDFS ()
		{
			var result = Creator.Create (10, 10);
			string s = result.ToString();
			Console.WriteLine (s);
		}
	}
}
