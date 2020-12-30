using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float totalMovementTime = 3f; //the amount of time you want the movement to take

    // Use this for initialization
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            //transform.position = new Vector3(waypoint.transform.position.x, 0f, waypoint.transform.position.z);
            StartCoroutine(MoveObjectSmoothly(waypoint));
            yield return new WaitForSeconds(2f);
        }
        print("Ending patrol");
    }

    public IEnumerator MoveObjectSmoothly(Waypoint waypoint)
    {
        float currentMovementTime = 0f;//The amount of time that has passed
        var destination = new Vector3(waypoint.transform.position.x, 0f, waypoint.transform.position.z);
        while (Vector3.Distance(transform.position, destination) > 0)
        {
            currentMovementTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, destination, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }
}