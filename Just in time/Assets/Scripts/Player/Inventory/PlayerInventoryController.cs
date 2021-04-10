﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] private float pocketCoolDown = 3f;

    private PlayerInventory _inventory;
    
    private bool _pocket1IsReady = true;
    private bool _pocket2IsReady = true;

    private void Start()
    {
        _inventory = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1) && _pocket1IsReady)
            StartCoroutine(UseConsumable(PlayerInventory.Pocket.Pocket1));

        if (Input.GetKey(KeyCode.Keypad2) && _pocket2IsReady)
            StartCoroutine(UseConsumable(PlayerInventory.Pocket.Pocket2));
    }

    public IEnumerator UseConsumable(PlayerInventory.Pocket pocket)
    {
        switch (pocket)
        {
            case PlayerInventory.Pocket.Pocket1:
                var consumableFromPocket1 = _inventory.GetItemFromPocket(PlayerInventory.Pocket.Pocket1, true);
                if (consumableFromPocket1 != null)
                {
                    consumableFromPocket1.Consume();
                    _pocket1IsReady = false;

                    yield return new WaitForSeconds(pocketCoolDown);
                }

                _pocket1IsReady = true;
                break;
            
            case PlayerInventory.Pocket.Pocket2:
                var consumableFormPocket2 = _inventory.GetItemFromPocket(PlayerInventory.Pocket.Pocket2, true);
                if (consumableFormPocket2 != null)
                {
                    consumableFormPocket2.Consume();
                    _pocket2IsReady = false;

                    yield return new WaitForSeconds(pocketCoolDown);
                }

                _pocket2IsReady = true;
                break;
        }
    }
}