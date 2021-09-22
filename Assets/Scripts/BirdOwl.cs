using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BirdOwl : Bird
{
    public float blastRadius = 2f;
    public float blastForce = 2f;

    private CircleCollider2D _blastCollider;

    public override void OnTap()
    {
        StartCoroutine(Explode());
    }

    public IEnumerator Explode()
    {
        _blastCollider = gameObject.AddComponent<CircleCollider2D>();
        _blastCollider.radius = blastRadius;
        _blastCollider.isTrigger = true;
        _blastCollider.enabled = true;

        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Obstacle") return;

        Vector2 direction = other.gameObject.transform.position - transform.position;
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * blastForce, ForceMode2D.Impulse);
    }

    private void OnDrawGizmos()
    {
        if (_blastCollider != null)
        {
            Gizmos.DrawWireSphere(transform.position, _blastCollider.radius);
        }
    }
}
