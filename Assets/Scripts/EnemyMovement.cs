using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        print("Starting patrol");
        foreach (Waypoint waypoint in path)
        {
            transform.position = new Vector3(waypoint.transform.position.x, 10f, waypoint.transform.position.z);
            print("Visiting block" + waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("Ending Patrol patrol");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
