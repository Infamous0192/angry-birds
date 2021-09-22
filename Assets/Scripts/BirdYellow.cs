using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdYellow : Bird
{
    public float boostForce = 100f;
    public bool hasBoost = false;

    public void Boost()
    {
        if (State == BirdState.Thrown && !hasBoost)
        {
            rigidBody.AddForce(rigidBody.velocity * boostForce);
            hasBoost = true;
        }
    }

    public override void OnTap()
    {
        Boost();
    }
}
