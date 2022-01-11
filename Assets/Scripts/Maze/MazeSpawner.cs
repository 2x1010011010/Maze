using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private Vector3 _cellSize = new Vector3();
    [SerializeField] private int _cellHight = 2;
    [SerializeField] private int _squareSize;
    [SerializeField] private Material _finish;
    [SerializeField] private Material _trap;
    [SerializeField] private int _trapsOnMazeCounter;
    private Cell[,] _spawnedCells;
    private MazeGeneratorCell[,] _cells;
    private Vector2Int _finishPosition;

    public Vector2Int FinishPosition => _finishPosition;
    public Vector3 CellSize => _cellSize;
    public MazeGeneratorCell[,] Cells => _cells;

    public event UnityAction MazeSpawned;

    private void Awake()
    {
        MazeGenerator generator = new MazeGenerator(_squareSize);
        _cells = generator.GenerateMaze();
        _spawnedCells = new Cell[_squareSize, _squareSize];

        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                Cell cell = Instantiate(_cellPrefab, new Vector3(x * _cellSize.x, y * _cellSize.y, y * _cellSize.z), _cellPrefab.transform.rotation).GetComponent<Cell>();
                cell.transform.localScale = new Vector3(_cellSize.x, _cellHight, _cellSize.z);
                cell.SetActiveCellComponents(_cells[x, y].WallLeft, _cells[x, y].WallBottom, _cells[x, y].Floor);
                _spawnedCells[x, y] = cell;
            }
        }
        _finishPosition = new Vector2Int(_squareSize - 2, _squareSize - 2);
        _spawnedCells[_finishPosition.x, _finishPosition.y].SetFloorColor(_finish);
        while (_trapsOnMazeCounter > 0)
        {
            SetTrapsOnMaze();
        }

        MazeSpawned?.Invoke();
    }

    private void SetTrapsOnMaze() 
    {
        int x = Random.Range(1, _squareSize - 2);
        int y = Random.Range(1, _squareSize - 2);

        if (x != 0 && y != 0 || x != _squareSize - 2 && y != _squareSize - 2)
        {
            if (!_spawnedCells[x, y].IsTrap)
            {
                _spawnedCells[x, y].SetFloorColor(_trap);
                _spawnedCells[x, y].SetCellIsTrap();
                _trapsOnMazeCounter--;
            }
        }
    }
}
