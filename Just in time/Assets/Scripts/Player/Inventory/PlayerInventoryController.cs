using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerInventoryController : MonoBehaviour
{
    private PlayerInventory _inventory;
    [SerializeField] private float speedBoosterCoolDown = 3f;
    [SerializeField] private float hpRegeneratorCoolDown = 3f;

    private bool _speedBoosterIsReady = true;
    private bool _hpRegeneratorIsReady = true;


    public enum ConsumerType
    {
        SpeedBoost,
        HpRegenerator
    }

    private void Start()
    {
        _inventory = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1) && _speedBoosterIsReady)
            StartCoroutine(UseConsumer(ConsumerType.SpeedBoost));

        if (Input.GetKey(KeyCode.Keypad2) && _hpRegeneratorIsReady)
            StartCoroutine(UseConsumer(ConsumerType.HpRegenerator));
    }

    public IEnumerator UseConsumer(ConsumerType consumerType)
    {
        switch (consumerType)
        {
            case ConsumerType.SpeedBoost:
                var speedBooster = _inventory.GetFirstItemInGivenPocket("SpeedBooster");
                if (speedBooster != null)
                {
                    _inventory.RemoveItem(speedBooster);
                    speedBooster.GetComponent<CoffeeController>().Consume();
                    _speedBoosterIsReady = false;

                    yield return new WaitForSeconds(speedBoosterCoolDown);
                }

                _speedBoosterIsReady = true;
                break;
            
            case ConsumerType.HpRegenerator:
                var hpBooster = _inventory.GetFirstItemInGivenPocket("HpRegenerator");
                if (hpBooster != null)
                {
                    _inventory.RemoveItem(hpBooster);
                    hpBooster.GetComponent<PaniniController>().Consume();
                    _hpRegeneratorIsReady = false;
                    
                    yield return new WaitForSeconds(hpRegeneratorCoolDown);
                }

                _hpRegeneratorIsReady = true;
                break;
        }
    }
}
