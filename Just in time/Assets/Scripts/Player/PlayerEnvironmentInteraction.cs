using System;
using TMPro;
using UnityEngine;

public class PlayerEnvironmentInteraction : MonoBehaviour
{
    public Vector3 ThrowableItemOffset;
    
    private DialogCloud _dialogCloudGameObject;
    public DialogCloud DialogCloudGameObject
    {
        get => _dialogCloudGameObject;
        set => _dialogCloudGameObject = value;
    }

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
