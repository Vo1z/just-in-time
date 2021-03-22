using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaniniController : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float hpRegeneration = 20f;
    
    [Header("Gizmos")] 
    [SerializeField] private float gizmosPositionOffset = 1.05f;
    [SerializeField] private bool isDisplayed = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerAttributes attributes = other.transform.GetComponent<PlayerAttributes>();

        if (attributes != null)
        {
            attributes.RegenerateHealth(hpRegeneration);
            Destroy(gameObject);
        }
    }
    
    private void OnDrawGizmos()
    {
        if (isDisplayed)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3.down * gizmosPositionOffset));
        }
    }
}
