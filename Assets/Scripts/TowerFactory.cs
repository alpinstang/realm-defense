using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int maxTowers = 5;
    Queue<Tower> towersQueue = new Queue<Tower>();

    Waypoint baseWaypoint;

    public void AddTower(Waypoint baseWaypoint)
    {
        if(towersQueue.Count < maxTowers)
        {
            InstantiateNewTower(baseWaypoint);
        } else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        var towerList = GameObject.FindGameObjectWithTag("Tower List");
        tower.transform.SetParent(towerList.transform);
        tower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        towersQueue.Enqueue(tower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        Tower oldTower = towersQueue.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;
        oldTower.transform.position = newBaseWaypoint.transform.position;
        oldTower.baseWaypoint = newBaseWaypoint;
        newBaseWaypoint.isPlaceable = false;
        towersQueue.Enqueue(oldTower);
    }


}
