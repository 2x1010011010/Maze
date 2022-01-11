using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsHandler : MonoBehaviour
{
    [SerializeField] private MazeSpawner _mazeSpawner;
    [SerializeField] private PlayerSpawner _playerSpawner;

    private void OnEnable()
    {
        _mazeSpawner.MazeSpawned += OnMazeSpawned;    
    }

    private void OnDisable()
    {
        _mazeSpawner.MazeSpawned -= OnMazeSpawned;
    }

    private void OnMazeSpawned()
    {
        _playerSpawner.Spawn();
    }
}
