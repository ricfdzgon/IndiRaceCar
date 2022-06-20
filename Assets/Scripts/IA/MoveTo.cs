using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MoveTo : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public Transform goal;
    private int currentWaypoint = 0;
    private int maxWaypoints = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        maxWaypoints = waypoints.Count;
    }

    void Update()
    {
        agent.destination = waypoints[currentWaypoint].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Waypoint")
        {
            currentWaypoint++;
            Debug.Log(currentWaypoint);
            Debug.Log(maxWaypoints);
        }
    }

}
