using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    private bool isRunning = true;
    Waypoint searchCenter;

    // Use this for initialization
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);
        while(queue.Count > 0)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbours(searchCenter);
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        if(!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {

            Vector2Int neighborCoordinates = from.GetGridPos() + direction;
            try
            {
                QueueNewNeighbors(neighborCoordinates);
            }
            catch
            {
                // do nothing
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        if(neighbor.isExplored || queue.Contains(neighbor))
        {
            // do nothing
        } else
        {
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;

        }

    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }


    }
}
