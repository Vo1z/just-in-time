using UnityEngine;

public class CoffeeController : MonoBehaviour
{
    [SerializeField] private float deltaSpeed = 800f;
    [SerializeField] private float speedUpTime = 1f;
    [SerializeField] private float timeToWaitForBoost = 5f; 

    [Header("Gizmos")] 
    [SerializeField] private float gizmosPositionOffset = 1.2f;
    [SerializeField] private bool isDisplayed = true;
    
    private PlayerAttributes _playerAttributes;
    private void Start()
    {
        _playerAttributes = GameController.SPlayer.PlayerAttributes;
    }

    public void Consume()
    {
        _playerAttributes.SpeedUp(deltaSpeed, speedUpTime, timeToWaitForBoost);
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