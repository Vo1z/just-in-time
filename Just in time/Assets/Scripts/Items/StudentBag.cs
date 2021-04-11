using UnityEngine;

///<sumary>Class for handling student bag item behaviour</sumary>
public class StudentBag : Item
{
    [SerializeField] [Min(0)] private int numberOfBonusSlotsInInventory = 3;

    public override void SetIsInInventory(bool isInInventory)
    {
        base.SetIsInInventory(isInInventory);

        if (isInInventory)
            _playerInventory.MaxNumberOfItems += numberOfBonusSlotsInInventory;
        else
            _playerInventory.MaxNumberOfItems -= numberOfBonusSlotsInInventory;
    }
}
