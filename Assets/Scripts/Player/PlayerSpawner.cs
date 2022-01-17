using System;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector3 _spawnPosition;


    internal void Spawn()
    {

        Instantiate(_prefab, _spawnPosition, Quaternion.identity);    
    }
}
