using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    #region Properties
    [Header("Refs")]
    [SerializeField] private Transform path;
    [SerializeField] private Transform cube;
    [Header("Properties")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float radius;
    #endregion

    #region Private
    private Vector3[] waypoints;
    private IEnumerator coroutine;
    #endregion

    #region Messages
    private void Awake()
    {
        waypoints = new Vector3[path.childCount];
        for (int i = 0; i < path.childCount; i++)
        {
            waypoints[i] = path.GetChild(i).position;
        }

        /*test*/
        cube.position = waypoints[0];
        MoveToWaypoint(waypoints[1]);
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

    #region Public
    public void MoveToWaypoint(Vector3 pos)
    {
        coroutine = MoveAlong(pos);
        StartCoroutine(coroutine);
    }
    #endregion

    #region Private Methods
    private IEnumerator MoveAlong(Vector3 pos)
    {
        while (true)
        {
            cube.position = Vector3.MoveTowards(cube.position, pos, speed * Time.deltaTime);
            if (cube.position == pos)
                yield return null;

            yield return null;
        }
    } 
    #endregion

}
