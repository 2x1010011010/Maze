using UnityEngine;

public class MazeGeneratorCell
{
    private int _coordinateX;
    private int _coordinateY;
    private bool _wallLeft = true;
    private bool _wallBottom = true;
    private bool _floor = true;
    private bool _visited = false;
    private int _distanceFromStart;

    public bool Visited => _visited;
    public bool WallLeft => _wallLeft;
    public bool WallBottom => _wallBottom;
    public bool Floor => _floor;
    public int X => _coordinateX;
    public int Y => _coordinateY;
    public int DistanceFromStart => _distanceFromStart;

    public MazeGeneratorCell(int x, int y)
    {
        _coordinateX = x;
        _coordinateY = y;
    }

    public void VisitCell()
    {
        _visited = true;
    }

    public void RemoveLeftWall()
    {
        _wallLeft = false;
    }

    public void RemoveBottomWall()
    {
        _wallBottom = false;
    }

    public void RemoveFloor() 
    {
        _floor = false;
    }

    public void SetDistanceFromStart(int value)
    {
        _distanceFromStart = value;
    }
}

