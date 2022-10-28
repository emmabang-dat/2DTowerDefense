using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float Speed;
    private Waypoints waypoints;

    private int waypointIndex;

    void Start()
    {
        waypoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints.waypoints[waypointIndex].position, Speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints.waypoints[waypointIndex].position) < 0.1f)
        {
            if (waypointIndex < waypoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
