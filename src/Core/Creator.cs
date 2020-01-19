/*
 * This file is part of MazeCreator.
 * 
 * Copyright (c)  2020 Vinicius Jarina (viniciusjarina@gmail.com)
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

using System;
using MazeCreator.Creator;

namespace MazeCreator.Core
{
	public enum Algorithm
	{
		DFS,
		Prim,
		Kruskal
	}

	public static class Creator
	{
		public static ICreator GetCreator (Algorithm algoritm = Algorithm.DFS, IRandomGenerator random = null)
		{
			if (random == null)
				random = new DefaultRandomGenerator ();

			ICreator creator = CreatorFromAlgorithm (algoritm);
			creator.Random = random;

			return creator;
		}

		static ICreator CreatorFromAlgorithm (Algorithm algorithm)
		{
			switch (algorithm) {
			case Algorithm.DFS:
				return new DFS ();
			case Algorithm.Prim:
				return new Prim ();
			case Algorithm.Kruskal:
				return new Kruskal ();
			}
			throw new InvalidOperationException ("Invalid algorithm parameter");
		}
	}
}
