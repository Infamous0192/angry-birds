using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    
    private bool _isHit = false;
    
    public UnityAction<GameObject> OnEnemyDestroyed = delegate { };

    private void OnDestroy()
    {
        OnEnemyDestroyed(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Rigidbody2D>() == null) return;

        if (other.gameObject.tag == "Bird")
        {
            _isHit = true;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            float damage = other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
            health -= damage;

            if (health <= 0)
            {
                _isHit = true;
                Destroy(gameObject);
            }
        }
    }
}
