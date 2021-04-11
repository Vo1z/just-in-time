using UnityEngine;

///<summary>Class that describes behaviour of ConsumableItem responsible for managing</summary>
public class ConsumableItem : Item
{
    [Header("Consumables option")]
    [SerializeField] protected float speedBoost;
    [SerializeField] protected float speedUpTime;
    [SerializeField] protected float timeToWaitForBoost;
    [SerializeField] protected float hpRegeneration;

    [Header("Gizmos")] 
    [SerializeField] private float gizmosPositionOffset = 1.2f;
    [SerializeField] private bool isDisplayed = true;

    protected PlayerAttributes _playerAttributes;
    
    protected new void Start()
    {
        base.Start();
        _playerAttributes = GameController.SPlayer.PlayerAttributes;
    }
    
    public virtual void Consume()
    {
        if(speedBoost > 0)
            _playerAttributes.SpeedUp(speedBoost, speedUpTime, timeToWaitForBoost);
        if(hpRegeneration > 0)
            _playerAttributes.Heal(hpRegeneration);
        
        Destroy(gameObject);
    }
    
    private void OnDrawGizmos()
    {
        if (!isDisplayed)
            return;

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down * gizmosPositionOffset));
    }
}
