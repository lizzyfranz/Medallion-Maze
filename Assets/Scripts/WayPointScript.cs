using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointScript : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentTarget = 0;
    public float speed;
    float epsilon = 0.1f;

    // Update is called once per frame
    void Update()
    {
        // If we arrived at our current target...
        if(Vector2.Distance(waypoints[currentTarget].transform.position, transform.position) < epsilon)
        {
            // ...advance to the next waypoint target
            print("Length: " + waypoints.Length + " currentTarget: " + currentTarget);
            currentTarget++;
            currentTarget = currentTarget % waypoints.Length;
        }
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currentTarget].transform.position, Time.deltaTime * speed);
    }
}
