using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // public ok here as is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;
    public bool hasTower = false;
    [SerializeField] Tower towerPrefab;

    Vector2Int gridPos;

    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    // consider setting own color in Update()

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CheckIfTowerCanBePlaced();
        }
    }

    private void CheckIfTowerCanBePlaced()
    {
        if (isPlaceable && !hasTower)
        {
            PlaceTower();
        }
        else if(isPlaceable && hasTower)
        {
            RemoveTower();
        }
    }

    private void RemoveTower()
    {
        // TODO: Remove tower system
    }

    private void PlaceTower()
    {
        var tower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
        var towerList = GameObject.FindGameObjectWithTag("Tower List");
        tower.transform.SetParent(towerList.transform);
        hasTower = true;
    }
}