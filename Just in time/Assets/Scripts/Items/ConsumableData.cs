using UnityEngine;

[CreateAssetMenu(fileName = "NewConsumableData", menuName = "ConsumablesData/ConsumableData")]
public class ConsumableData : ScriptableObject
{
    public float SpeedBoost;
    public float SpeedUpTime;
    public float TimeToWaitForBoost;
    public float HpRegeneration;
}
