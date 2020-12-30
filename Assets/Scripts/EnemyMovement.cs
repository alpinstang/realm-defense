using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = 0.5f; //the amount of time you want the movement to take
    [SerializeField] float transitionTime = 1f; //the amount of time you want the movement to take
    [SerializeField] ParticleSystem GoalParticles;

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
            yield return new WaitForSeconds(movementPeriod);
        }
        StartCoroutine(SelfDestruct());
    }

    public IEnumerator SelfDestruct()
    {
        var vfx = Instantiate(GoalParticles, transform.position, Quaternion.identity);
        var enemyVfx = GameObject.FindGameObjectWithTag("VFX List");
        vfx.transform.SetParent(enemyVfx.transform);
        vfx.Play();
        Destroy(gameObject);
        Destroy(vfx.gameObject, vfx.main.duration);
        yield return new WaitForSeconds(1f);

    }

    public IEnumerator MoveObjectSmoothly(Waypoint waypoint)
    {
        float currentMovementTime = 0f;//The amount of time that has passed
        var destination = new Vector3(waypoint.transform.position.x, 0f, waypoint.transform.position.z);
        while (Vector3.Distance(transform.position, destination) > 0)
        {
            currentMovementTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, destination, currentMovementTime / transitionTime);
            yield return null;
        }
    }
}