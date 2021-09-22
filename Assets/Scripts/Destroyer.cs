using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        string otherTag = other.gameObject.tag;
        if (otherTag == "Bird" || otherTag == "Enemy" || otherTag == "Obstacle")
        {
            Destroy(other.gameObject);
        }
    }
}
