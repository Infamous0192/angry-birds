using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShooter : MonoBehaviour
{
    public CircleCollider2D circleCollider;
    public LineRenderer trajectory;
    
    private Vector2 _startPos;

    [SerializeField] private float radius = 0.75f;
    [SerializeField] private float throwSpeed = 30f;

    private Bird _bird;
    private void Start()
    {
        _startPos = transform.position;
    }

    private void OnMouseUp()
    {
        circleCollider.enabled = false;
        Vector2 velocity = _startPos - (Vector2) transform.position;
        float distance = Vector2.Distance(_startPos, transform.position);
        
        _bird.Shoot(velocity, distance, throwSpeed);

        gameObject.transform.position = _startPos;
        trajectory.enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = point - _startPos;
        if (direction.sqrMagnitude > radius)
        {
            direction = direction.normalized * radius;
        }

        transform.position = _startPos + direction;

        float distance = Vector2.Distance(_startPos, transform.position);

        if (!trajectory.enabled)
        {
            trajectory.enabled = true;
        }
        
        DisplayTrajectory(distance);
    }

    public void InstantiateBird(Bird bird)
    {
        _bird = bird;
        _bird.MoveTo(transform.position, gameObject);
        circleCollider.enabled = true;
    }

    private void DisplayTrajectory(float distance)
    {
        if (_bird == null) return;

        var position = transform.position;
        Vector2 velocity = _startPos - (Vector2) position;
        int segmentCount = 5;
        Vector2[] segments = new Vector2[segmentCount];

        segments[0] = position;

        Vector2 segVelocity = velocity * throwSpeed * distance;

        for (int i = 1; i < segmentCount; i++)
        {
            float elapsedTime = i * Time.fixedDeltaTime * 5;
            segments[i] = segments[0] + 
                          segVelocity * elapsedTime +
                          0.5f * Physics2D.gravity * Mathf.Pow(elapsedTime, 2);
        }

        trajectory.positionCount = segmentCount;
        for (int i = 0; i < segmentCount; i++)
        {
            trajectory.SetPosition(i, segments[i]);
        }

    }
}
