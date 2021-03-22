using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ThrowableObjectController : MonoBehaviour
{
    [SerializeField] private float throwingForce = 5f;

    public float ThrowingForce => throwingForce;

    private void OnCollisionEnter(Collision other)
    {
        if (other != null)
        {
            var throwableObjectHandler = other.gameObject.GetComponent<ThrowableObjectHandler>();

            if (throwableObjectHandler != null)
                throwableObjectHandler.ThrowableObject = gameObject;
        }
    }
}
