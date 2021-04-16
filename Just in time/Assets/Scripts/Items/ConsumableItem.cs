using JetBrains.Annotations;
using UnityEngine;

///<summary>Class that describes behaviour of ConsumableItem and responsible for managing</summary>
public class ConsumableItem : Item
{
    [Header("Consumables option")] 
    [SerializeField] [NotNull]private ConsumableData consumableData;

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
        if(consumableData.SpeedBoost > 0)
            _playerAttributes.SpeedUp(consumableData.SpeedBoost,
                consumableData.SpeedUpTime, consumableData.TimeToWaitForBoost);
        if(consumableData.HpRegeneration > 0)
            _playerAttributes.Heal(consumableData.HpRegeneration);

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