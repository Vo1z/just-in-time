using UnityEngine;

public class PaniniController : ConsumableItem
{
    [Header("Gizmos")] 
    [SerializeField] private float gizmosPositionOffset = 1.05f;
    [SerializeField] private bool isDisplayed = true;

    private new void Start()
    {
        base.Start();
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
