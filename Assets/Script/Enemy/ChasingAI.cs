using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class ChasingAI : MonoBehaviour
{
    public Transform playerTransform;
    public Seeker seeker;
    public Path path;
    public float speed;
    public Vector2 startPosition;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Coroutine moveCoroutine;
    public float nextWaypointDistance = 0.1f; // khoảng cách giữa enemy và điểm waypoint tiếp theo
    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        InvokeRepeating("CalcutatePath", 0f, 0.5f);
    }
    void CalcutatePath()
    {
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        if (distance > 10f)
        {
            Invoke("CalcutatePathToBegin", 1.5f);
        }
        else
        {
            if (seeker.IsDone())
            {
                seeker.StartPath(transform.position, playerTransform.position, OnPathComplete);
            }
        }
    }
    void CalcutatePathToBegin()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(transform.position, startPosition, OnPathComplete);
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
            Vector2 force = direction * speed * Time.deltaTime;
            transform.Translate(force);
            // Nếu đến gần waypoint, chuyển sang waypoint tiếp theo
            if (Vector2.Distance(transform.position, nextWaypoint) < nextWaypointDistance)
            {
                currentWaypoint++;
            }
            yield return null;
        }
    }
}
