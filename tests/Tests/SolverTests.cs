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

using System.Linq;

using NUnit.Framework;

using MazeCreator.Core;
using MazeCreator;

namespace MazeCreatorTest.Tests
{
	[TestFixture]
	public class SolverTests
	{
		[Test]
		public void DefaultSolver ()
		{
			var random = new TestRandomGenerator ();
			ICreator creator = Creator.GetCreator (Algorithm.DFS, random);
			Maze maze = creator.Create (3, 3);

			IMazeSolver solver = Solver.Create (random);

			PositionDirection [] steps = solver.Solve (maze, new Position (0, 0), new Position (2, 2));

			PositionDirection [] expected = {
				new PositionDirection (new Position (0,0), Direction.Left),
				new PositionDirection (new Position (0,1), Direction.Down),
				new PositionDirection (new Position (1,1), Direction.Left),
				new PositionDirection (new Position (1,2), Direction.Down),
			};
			Assert.True (expected.SequenceEqual (steps), "#1");
		}
	}
}
