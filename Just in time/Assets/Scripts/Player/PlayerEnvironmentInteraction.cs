﻿using UnityEngine;

public class PlayerEnvironmentInteraction : MonoBehaviour
{
    public Vector3 ThrowableItemOffset;

    [SerializeField] private bool IsOn = true;
    private void OnDrawGizmos()
    {
        if (IsOn)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawCube(transform.position + ThrowableItemOffset, Vector3.one);
        }
    }
}
