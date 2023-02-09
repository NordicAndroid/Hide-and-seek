using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomWaypoint : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] Waypoints;
    int WaypointNum;
    Vector3 CurrentWaypoint;

   private void Start()
    {
        WaypointNum = Random.Range(0, Waypoints.Length - 1);
        CurrentWaypoint = Waypoints[WaypointNum].position;
        agent.SetDestination(CurrentWaypoint);
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, CurrentWaypoint) < 0.75f )//gameObject.GetComponent<CapsuleCollider>().bounds.Contains(CurrentWaypoint))//transform.position == Waypoints[WaypointNum].position
        {
            //Debug.Log("Waypoint number " + WaypointNum + " Reached");
            WaypointNum = Random.Range(0, Waypoints.Length-1);
            CurrentWaypoint = Waypoints[WaypointNum].position;
            agent.SetDestination(CurrentWaypoint);
            //Debug.Log("Moving to waypoint number " + WaypointNum);

        }
    }
}
