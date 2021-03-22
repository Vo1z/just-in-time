using UnityEngine;

public class CoffeeController : MonoBehaviour
{
    [SerializeField] private float deltaSpeed = 800f;
    [SerializeField] private float speedUpTime = 1f;
    [SerializeField] private float timeToWaitForBoost = 5f; 

    [Header("Gizmos")] 
    [SerializeField] private float gizmosPositionOffset = 1.2f;

    [SerializeField] private bool isDisplayed = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerAttributes attributes = other.transform.GetComponent<PlayerAttributes>();

        if (attributes != null)
        {
            attributes.SpeedUp(deltaSpeed, speedUpTime, timeToWaitForBoost);
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
