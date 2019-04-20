
Maze Creator
=============

| NuGet |
| ------|
|[![nuget](https://badgen.net/nuget/v/MazeCreator?icon=nuget)](https://www.nuget.org/packages/MazeCreator)|

|  | Status | 
| :------ | :------: | 
| **Linux**   | [![Linux](https://travis-ci.org/codefoco/MazeCreator.svg?branch=master)](https://travis-ci.org/codefoco/MazeCreator) |
| **AppVeyor** | [![Build status](https://ci.appveyor.com/api/projects/status/jkqcy9m9k35jwolx?svg=true)](https://ci.appveyor.com/project/viniciusjarina/mazecreator)|
|**Mac (VSTS)** | [![Build Status](https://codefoco.visualstudio.com/_apis/public/build/definitions/4f3cd26e-b8f7-4e52-9e78-c2ecf3de2929/1/badge)](https://codefoco.visualstudio.com/BlueMaze/_build/index?context=mine&path=%5C&definitionId=1&_a=completed) |
|**Windows (VSTS)** | [![Build Status](https://codefoco.visualstudio.com/_apis/public/build/definitions/4f3cd26e-b8f7-4e52-9e78-c2ecf3de2929/2/badge)](https://codefoco.visualstudio.com/BlueMaze/_build/index?context=mine&path=%5C&definitionId=2&_a=completed) |


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

