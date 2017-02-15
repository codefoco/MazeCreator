/*
 * This file is part of MazeCreator.
 * 
 * Copyright (c) 2017 Vinicius Jarina (viniciusjarina@gmail.com)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using NUnit.Framework;

using MazeCreator.Core;
using MazeCreator.Extensions;
using System;

namespace MazeCreatorTest.Tests
{
	[TestFixture]
	public class CreatorTests
	{
		[Test]
		public void DFS ()
		{
			var random = new TestRandomGenerator ();
			ICreator creator = Creator.GetCreator (Algorithm.DFS, random);
			Maze maze = creator.Create (10, 10);
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
			expected = expected.Replace ("\n", Environment.NewLine);
			Assert.AreEqual (expected, s);
		}

		[Test]
		public void Kruskal ()
		{
			var random = new TestRandomGenerator ();
			ICreator creator = Creator.GetCreator (Algorithm.Kruskal, random);
			Maze maze = creator.Create (10, 10);
			string s = maze.ToBoxString ();

			string expected =
@"┌─┬───┬─────┬───┬───┐ 
│ ╵ ╶─┤ ╷ ╶─┴─╴ │ ╷ │ 
├─╴ ╶─┘ │ ╷ ┌─╴ ╵ └─┤ 
├─╴ ╷ ╷ └─┼─┴─┬───┬─┤ 
│ ╶─┼─┤ ┌─┘ ╷ ├─╴ │ │ 
│ ╷ │ ╵ │ ╷ │ └─┐ │ │ 
├─┴─┘ ╷ └─┘ │ ╶─┤ │ │ 
├───╴ ├─╴ ┌─┴───┘ ╵ │ 
├─┬─┐ │ ╷ └─╴ ╶─┬─╴ │ 
│ ╵ └─┘ │ ╷ ┌───┘ ╶─┤ 
└───────┴─┴─┴───────┘ 
";
			expected = expected.Replace ("\n", Environment.NewLine);
			Assert.AreEqual (expected, s);
		}

		[Test]
		public void Prim ()
		{
			var random = new TestRandomGenerator ();
			ICreator creator = Creator.GetCreator (Algorithm.Prim, random);
			Maze maze = creator.Create (10, 10);
			string s = maze.ToBoxString ();

			string expected =
@"┌─┬─┬─────┬─┬─────┬─┐ 
│ ╵ ╵ ╷ ╷ ╵ ╵ ╶───┘ │ 
│ ┌─╴ │ │ ╶─┐ ╶─┐ ┌─┤ 
│ │ ╷ └─┤ ┌─┘ ╶─┴─┘ │ 
│ └─┼─╴ ├─┘ ╷ ╶─┐ ╷ │ 
│ ╷ │ ╷ ├─╴ │ ╷ ├─┤ │ 
├─┘ ├─┘ └─┐ └─┴─┘ │ │ 
│ ╷ ├─┬───┘ ┌─╴ ╷ └─┤ 
│ │ │ ╵ ╶─┐ └─┐ │ ╷ │ 
│ └─┼─╴ ╷ ├───┴─┘ └─┤ 
└───┴───┴─┴─────────┘ 
";
			expected = expected.Replace ("\n", Environment.NewLine);
			Assert.AreEqual (expected, s);
		}

		[Test]
		public void NotificationCreate ()
		{
			int position = 0;
			int walls = 0;
			var random = new TestRandomGenerator ();
			ICreator creator = Creator.GetCreator (Algorithm.DFS, random);
			creator.PositionVisited = (m, p) => {
				position++;
			};

			creator.WallRemoved = (m, p, nextPosition, direction) => {
				walls++;
			};

			creator.Create (10, 10);

			Assert.AreEqual (167, position);
			Assert.AreEqual (99, walls);
		}
		
	}
}
