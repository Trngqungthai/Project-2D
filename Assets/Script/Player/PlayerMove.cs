using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerMove : MonoBehaviour
{
    public Transform playerTransform;
    public Transform targer;
    public Path path;
    public Seeker seeker;
    private Coroutine moveCoroutine;
    public float nextWaypointDistance = 0.1f;
    public PlayerController player;
    void CalcutatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(playerTransform.position, targer.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            // Bắt đầu di chuyển tới đích
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            moveCoroutine = StartCoroutine(FollowPath());
        }
    }
    IEnumerator FollowPath()
    {
        int currentWaypoint = 0;
        bool reachedEndOfPath = false;
        while (!reachedEndOfPath)
        {
            if (path == null)
            {
                yield break;
            }

            if (currentWaypoint >= path.vectorPath.Count) // Đã đi đến cuối đường đi
            {
                reachedEndOfPath = true;
                yield break;
            }
            // Di chuyển đến waypoint tiếp theo
            Vector2 nextWaypoint = path.vectorPath[currentWaypoint];
            Vector2 direction = (nextWaypoint - (Vector2)transform.position).normalized;
            Vector2 force = direction * player.moveSpeed * Time.deltaTime;
            transform.Translate(force);
            yield return null;
        }
    }    
}
