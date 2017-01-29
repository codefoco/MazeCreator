Maze Creator
============

This library will help you to create simple Mazes.

    using MazeCreator.Core;

    Maze maze = Creator.Create (10, 10);

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

    Maze maze = Creator.Create (10, 10, Algorithm.Kruskal)

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

