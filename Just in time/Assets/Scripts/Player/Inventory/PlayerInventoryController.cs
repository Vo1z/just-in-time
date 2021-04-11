using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Class that is responsible for external players inventory control</summary>
[RequireComponent(typeof(PlayerInventory))]
public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] private float pocketCoolDown = 3f;

    private PlayerInventory _playerInventory;
    private List<Item> _specialItems;

    private bool _pocket1IsReady = true;
    private bool _pocket2IsReady = true;

    private void Start()
    {
        _playerInventory = GetComponent<PlayerInventory>();
        _specialItems = _playerInventory.SpecialItems;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1) && _pocket1IsReady)
            StartCoroutine(UseConsumable(PlayerInventory.Pocket.Pocket1));

        if (Input.GetKey(KeyCode.Keypad2) && _pocket2IsReady)
            StartCoroutine(UseConsumable(PlayerInventory.Pocket.Pocket2));
        
        if (Input.GetKey(KeyCode.G) && _specialItems.Count > 0)
            _playerInventory.DropSpecialItem(_specialItems[_specialItems.Count - 1], transform.position);
    }

    public IEnumerator UseConsumable(PlayerInventory.Pocket pocket)
    {
        switch (pocket)
        {
            case PlayerInventory.Pocket.Pocket1:
                var consumableFromPocket1 =
                    _playerInventory.GetItemFromPocket(PlayerInventory.Pocket.Pocket1, true);
                if (consumableFromPocket1 != null)
                {
                    consumableFromPocket1.Consume();
                    _pocket1IsReady = false;

                    yield return new WaitForSeconds(pocketCoolDown);
                }

                _pocket1IsReady = true;
                break;
            
            case PlayerInventory.Pocket.Pocket2:
                var consumableFormPocket2 =
                    _playerInventory.GetItemFromPocket(PlayerInventory.Pocket.Pocket2, true);
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