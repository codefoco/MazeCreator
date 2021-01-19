/*
 * This file is part of MazeCreator.
 * 
 * Copyright (c)  2021 Vinicius Jarina (viniciusjarina@gmail.com)
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
		EmptyCell    = 0x00,      // [ 0 0 0 0 ][ 0 0 0 0 ]
		TopWall      = 0x01,      // [ 0 0 0 0 ][ 0 0 0 1 ]
		LeftWall     = 0x02,      // [ 0 0 0 0 ][ 0 0 1 0 ]
		BottomWall   = 0x10,      // [ 0 0 0 1 ][ 0 0 0 0 ]
		RightWall    = 0x20,      // [ 0 0 1 0 ][ 0 0 0 0 ]
		AllWalls     = 0x33,      // [ 0 0 1 1 ][ 0 0 1 1 ]

		TopBorder    = 0x40,      // [ 0 1 0 0 ][ 0 0 0 0 ]
		LeftBorder   = 0x80,      // [ 1 0 0 0 ][ 0 0 0 0 ]
		BottomBorder = 0x04,      // [ 0 0 0 0 ][ 0 1 0 0 ]
		RightBorder  = 0x08,      // [ 0 0 0 0 ][ 1 0 0 0 ]

		RemoveBorders = 0x33,      // [ 0 0 1 1 ][ 0 0 1 1 ]

		CodeMask = 0x0F,           // [ 0 0 1 1 ][ 1 1 1 1 ]

		RemoveTopWall    = 0xFE,  // [ 1 1 1 1 ][ 1 1 1 0 ]
		RemoveLeftWall   = 0xFD,  // [ 1 1 1 1 ][ 1 1 0 1 ]
		RemoveBottomWall = 0xEF,  // [ 1 1 1 0 ][ 1 1 1 1 ]
		RemoveRightWall  = 0xDF,  // [ 1 1 0 1 ][ 1 1 1 1 ]

		UpLeftCellRightWall  = 0x04,// [ 0 0 0 0 ][ 0 1 0 0 ]
		UpLeftCellBottomWall = 0x08,// [ 0 0 0 0 ][ 1 0 0 0 ]
	}
}
