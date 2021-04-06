using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : Item
{
    [Header("Consumables option")]
    [SerializeField] protected float speedBoost;
    [SerializeField] protected float speedUpTime;
    [SerializeField] protected float timeToWaitForBoost;
    [SerializeField] protected float hpRegeneration;


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
            _playerAttributes.RegenerateHealth(hpRegeneration);
        
        Destroy(gameObject);
    }
}
