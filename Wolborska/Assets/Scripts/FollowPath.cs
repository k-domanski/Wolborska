using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    #region Properties
    [Header("Refs")]
    [SerializeField] private Transform path;
    [Header("Properties")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float triggerRadius = 4f;
    #endregion

    #region Private
    private Vector3[] waypoints;
    private IEnumerator coroutine;
    private SphereCollider trigger;
    private int nextWaypointIndex = 0;
    #endregion

    #region Messages
    private void Awake()
    {
        waypoints = new Vector3[path.childCount];
        for (int i = 0; i < path.childCount; i++)
        {
            waypoints[i] = path.GetChild(i).position;
        }

        trigger = GetComponent<SphereCollider>();
        trigger.radius = triggerRadius;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            MoveToWaypoint(waypoints[nextWaypointIndex]);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector3 startPosition = path.GetChild(0).position;
        Vector3 previousPositon = startPosition;

        foreach (Transform waypoint in path)
        {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(previousPositon, waypoint.position);
            previousPositon = waypoint.position;
        }
    }
#endif
    #endregion

    #region Private Methods
    private void MoveToWaypoint(Vector3 pos)
    {
        coroutine = MoveAlong(pos);
        StartCoroutine(coroutine);
    }

    private IEnumerator MoveAlong(Vector3 pos)
    {
        while (transform.position != pos)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
            yield return null;
        }

        if(nextWaypointIndex != waypoints.Length - 1)
            nextWaypointIndex++;

        yield return null;
    } 
    #endregion

}
