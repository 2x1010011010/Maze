using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private GameObject _wallLeft;
    [SerializeField] private GameObject _wallBottom;
    [SerializeField] private GameObject _floor;
    private bool _isTrap = false;
    public bool IsTrap => _isTrap;

    public void SetActiveCellComponents(bool leftWall, bool bottomWall, bool floor)
    {
        _wallLeft.SetActive(leftWall);
        _wallBottom.SetActive(bottomWall);
        _floor.SetActive(floor);
    }

    public void SetFloorColor(Material material) 
    {
        _floor.GetComponent<MeshRenderer>().material = material;
    }

    public void SetCellIsTrap()
    {
        _isTrap = true;
    }
}
