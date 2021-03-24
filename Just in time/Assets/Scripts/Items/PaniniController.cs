using UnityEngine;

public class PaniniController : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float hpRegeneration = 20f;
    
    [Header("Gizmos")] 
    [SerializeField] private float gizmosPositionOffset = 1.05f;
    [SerializeField] private bool isDisplayed = true;

    private PlayerAttributes _playerAttributes;

    private void Start()
    {
        _playerAttributes = GameController.SPlayer.PlayerAttributes;
    }

    public void Consume()
    {
        _playerAttributes.RegenerateHealth(hpRegeneration);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerInventory = other.transform.GetComponent<PlayerInventory>();

        if (playerInventory != null)
            playerInventory.AddItem(gameObject, false);
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
