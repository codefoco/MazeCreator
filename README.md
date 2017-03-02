Maze Creator
=============

|  | Status | 
| :------ | :------: | 
| **Linux**   | [![Linux](https://travis-ci.org/codefoco/MazeCreator.svg?branch=master)](https://travis-ci.org/codefoco/MazeCreator) |
| **Windows** | [![Build status](https://ci.appveyor.com/api/projects/status/jkqcy9m9k35jwolx?svg=true)](https://ci.appveyor.com/project/viniciusjarina/mazecreator)|

This library will help you to create simple Mazes.

    using MazeCreator.Core;

    Maze maze = Creator.GetCreator ().Create (10, 10);

This will create a maze 10 x 10:

    ┌───────────┬─┬─┬───┐ 
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

To get cell information you can do:

    // maze [line, column]
    Cell cell = maze [0, 1];
    if (cell.HasRightWall) {
        ...
    }
    if (cell.HasLeftWall) {
        ...
    }
    if (cell.HasBottomWall) {
        ...
    }
    if (cell.HasTopWall) {
        ...
    }


Building
--------

    msbuild


Kruskal
--------

To create a maze using Kruskal algorithm use:

    Maze maze = Creator.GetCreator (Algorithm.Kruskal).Create (10, 10)

This will create a maze like:

    ┌─┬───┬─────┬───┬───┐ 
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


Prim
--------

To create a maze using Prim algorithm use:

    Maze maze = Creator.GetCreator (Algorithm.Prim).Create (10, 10)

This will create a maze like:


    ┌─┬─┬─────┬─┬─────┬─┐ 
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

