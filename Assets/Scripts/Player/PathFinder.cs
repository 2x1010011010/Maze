using System.Collections.Generic;
using UnityEngine;

public class PathFinder
{
    private MazeSpawner _mazeSpawner;
    private List<Vector3> _positions = new List<Vector3>();

    public List<Vector3> FindPath()
    {
        int x = _mazeSpawner.FinishPosition.x;
        int y = _mazeSpawner.FinishPosition.y;

        while (x != 0 || y != 0)
        {
            _positions.Add(new Vector3(x * _mazeSpawner.CellSize.x, y * _mazeSpawner.CellSize.y, y * _mazeSpawner.CellSize.z));

            MazeGeneratorCell currentCell = _mazeSpawner.Cells[x, y];

            if (x > 0 &&
                !currentCell.WallLeft &&
                _mazeSpawner.Cells[x - 1, y].DistanceFromStart < currentCell.DistanceFromStart)
            {
                x--;
            }
            else if (y > 0 &&
                !currentCell.WallBottom &&
                _mazeSpawner.Cells[x, y - 1].DistanceFromStart < currentCell.DistanceFromStart)
            {
                y--;
            }
            else if (x < _mazeSpawner.Cells.GetLength(0) - 1 &&
                !_mazeSpawner.Cells[x + 1, y].WallLeft &&
                _mazeSpawner.Cells[x + 1, y].DistanceFromStart < currentCell.DistanceFromStart)
            {
                x++;
            }
            else if (y < _mazeSpawner.Cells.GetLength(1) - 1 &&
                !_mazeSpawner.Cells[x, y + 1].WallBottom &&
                _mazeSpawner.Cells[x, y + 1].DistanceFromStart < currentCell.DistanceFromStart)
            {
                y++;
            }
        }

        _positions.Add(Vector3.zero);

        return _positions;
    }
}
