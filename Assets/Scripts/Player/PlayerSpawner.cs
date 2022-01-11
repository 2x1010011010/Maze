using System;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private GameObject _prefab;

    internal void Spawn()
    {
        Instantiate(_prefab, _spawnPosition, Quaternion.identity);    
    }
}
