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

using System;

namespace MazeCreator.Core
{
	[Flags]
	public enum CellInfo : byte
	{
		// CellInfo:
		//                           [-border--][--walls--]
		EmptyCell    = 0xFF,      // [ 1 1 1 1 ][ 1 1 1 1 ]
		TopWall      = 0xFE,      // [ 1 1 1 1 ][ 1 1 1 0 ]
		LeftWall     = 0xFD,      // [ 1 1 1 1 ][ 1 1 0 1 ]
		BottomWall   = 0xFB,      // [ 1 1 1 1 ][ 1 0 1 1 ]
		RightWall    = 0xF7,      // [ 1 1 1 1 ][ 0 1 1 1 ]
		AllWalls     = 0xF0,      // [ 1 1 1 1 ][ 0 1 1 1 ]

		TopBorder    = 0xEF,      // [ 1 1 1 0 ][ 1 1 1 1 ]
		LeftBorder   = 0xDF,      // [ 1 1 0 1 ][ 1 1 1 1 ]
		BottomBorder = 0xBF,      // [ 1 0 1 1 ][ 1 1 1 1 ]
		RightBorder  = 0x7F,      // [ 0 1 1 1 ][ 1 1 1 1 ]

		RemoveTopWall    = 0x01,  // [ 0 0 0 0 ][ 0 0 0 1 ]
		RemoveLeftWall   = 0x02,  // [ 0 0 0 0 ][ 0 0 1 0 ]
		RemoveBottomWall = 0x04,  // [ 0 0 0 0 ][ 0 1 0 0 ]
		RemoveRightWall  = 0x08,  // [ 0 0 0 0 ][ 1 0 0 0 ]
	}
}
