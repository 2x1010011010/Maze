using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator
{
    private int _width;
    private int _height;
    
    public MazeGenerator(int fieldSize) 
    {
        _width = fieldSize;
        _height = fieldSize;
    }

    public MazeCell[,] GenerateMaze() 
    {
        MazeCell[,] mazeCells = new MazeCell[_width, _height];

        for (int x = 0; x < mazeCells.GetLength(0); x++)
        {
            for (int y = 0; y < mazeCells.GetLength(1); y++)
            {
                mazeCells[x, y] = new MazeCell(x, y);
            }
        }

        RemoveWalls(mazeCells);

        return mazeCells;
    }

    private void RemoveWalls(MazeCell[,] maze)
    {
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            maze[x, _height - 1].RemoveLeftWall();
            maze[x, _height - 1].RemoveFloor();
        }
        
        for (int y = 0; y < maze.GetLength(1); y++)
        {
            maze[_width - 1, y].RemoveBottomWall();
            maze[_width - 1, y].RemoveFloor();
        }

        MazeCell current = maze[0, 0];
        current.VisitCell();
        current.SetDistanceFromStart(0);

        Stack<MazeCell> stackCells = new Stack<MazeCell>();

        do
        {
            List<MazeCell> unvisitedCells = new List<MazeCell>();
            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].Visited)
            {
                unvisitedCells.Add(maze[x - 1, y]);
            }

            if (y > 0 && !maze[x, y - 1].Visited)
            {
                unvisitedCells.Add(maze[x, y - 1]);
            }

            if (x < _width - 2 && !maze[x + 1, y].Visited)
            {
                unvisitedCells.Add(maze[x + 1, y]);
            }

            if (y < _height - 2 && !maze[x, y + 1].Visited)
            {
                unvisitedCells.Add(maze[x, y + 1]);
            }

            if (unvisitedCells.Count > 0)
            {
                MazeCell chosen = unvisitedCells[UnityEngine.Random.Range(0, unvisitedCells.Count)];
                RemoveWall(current, chosen);
                chosen.VisitCell();
                current = chosen;
                stackCells.Push(current);
                current.SetDistanceFromStart(stackCells.Count);
            }
            else
            {
                current = stackCells.Pop();
            }


        } while (stackCells.Count > 0);

    }

    private void RemoveWall(MazeCell current, MazeCell chosen)
    {
        if (current.X == chosen.X)
        {
            if (current.Y > chosen.Y)
                current.RemoveBottomWall();
            else
                chosen.RemoveBottomWall();
        }
        else
        {
            if (current.X > chosen.X)
                current.RemoveLeftWall();
            else
                chosen.RemoveLeftWall();
        }
    }
}
