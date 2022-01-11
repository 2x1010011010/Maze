using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private PathFinder _pathFinder;
    private List<Vector3> _pathPoints = new List<Vector3>();

    private void Start()
    {
        _pathFinder = GetComponent<PathFinder>();
        _pathPoints = _pathFinder.FindPath();
        foreach(var point in _pathPoints)
            Debug.Log(point.x + " " + point.y + " " + point.z);
    }
}
