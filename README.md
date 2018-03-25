
Maze Creator
=============

| NuGet | NuGet (Pre-Release) |
| ------|------|
|[![nuget](https://img.shields.io/nuget/v/MazeCreator.svg)](https://www.nuget.org/packages/MazeCreator)|[![nuget](https://img.shields.io/nuget/vpre/MazeCreator.svg)](https://www.nuget.org/packages/MazeCreator)|

|  | Status | 
| :------ | :------: | 
| **Linux**   | [![Linux](https://travis-ci.org/codefoco/MazeCreator.svg?branch=master)](https://travis-ci.org/codefoco/MazeCreator) |
| **AppVeyor** | [![Build status](https://ci.appveyor.com/api/projects/status/jkqcy9m9k35jwolx?svg=true)](https://ci.appveyor.com/project/viniciusjarina/mazecreator)|
|**Mac (Jenkins)** | [![Build Status](http://jenkins.codefoco.com:8085/buildStatus/icon?job=MazeCreator.Mac)](http://jenkins.codefoco.com:8085/job/MazeCreator.Mac/) |
|**Windows (Jenkins)** | [![Build Status](http://jenkins.codefoco.com:8085/buildStatus/icon?job=MazeCreator.Windows)](http://jenkins.codefoco.com:8085/job/MazeCreator.Windows/) |


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

