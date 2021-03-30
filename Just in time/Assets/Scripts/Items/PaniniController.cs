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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player")) 
            _playerInventory.AddItem(this, false);
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
