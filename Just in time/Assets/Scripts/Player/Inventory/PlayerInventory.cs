using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField][Range(0, 10)]
    private int maxNumberOfItems = 5;
    [SerializeField] [Range(0, 10)] private float itemDropCooldown = 0.3f;

    private List<Item> _specialItems = new List<Item>();
    private Stack<ConsumableItem> _pocket1 = new Stack<ConsumableItem>();
    private Stack<ConsumableItem> _pocket2 = new Stack<ConsumableItem>();

    public List<Item> SpecialItems => _specialItems;
    public int CurrentNumberOfItems => _pocket1.Count + _pocket2.Count + _specialItems.Count;
    public int MaxNumberOfItems => maxNumberOfItems;

    private bool _dropIsAvailable = true;
    public enum Pocket
    {
        Pocket1,
        Pocket2,
    }
    
    public bool AddItem(Item item, bool setActive) 
    {
        if (CurrentNumberOfItems < maxNumberOfItems && item != null)
        {
            if (item is ConsumableItem)
            {
                if (_pocket1.Count >= _pocket2.Count)
                    _pocket2.Push((ConsumableItem)item);
                else
                    _pocket1.Push((ConsumableItem)item);
            }
            else
            {
                _specialItems.Add(item);
            }

            item.gameObject.SetActive(setActive);
            
            return true;
        }

        return false;
    }

    public ConsumableItem GetItemFromPocket(Pocket pocket, bool removeItem = false)
    {
        switch (pocket)
        {
            case Pocket.Pocket1:
                if (_pocket1.Count > 0)
                {
                    if (removeItem)
                        return _pocket1.Pop();
                    return _pocket1.Peek();
                }
                else
                    return null;

            case Pocket.Pocket2:
                if (_pocket2.Count > 0)
                {
                    if (removeItem)
                        return _pocket2.Pop();
                    return _pocket2.Peek();
                }
                else
                    return null;
        }
        return null;
    }

    public Stack<ConsumableItem> GetPocket(Pocket pocket)
    {
        switch (pocket)
        {
            case Pocket.Pocket1:
                return _pocket1;
            case Pocket.Pocket2:
                return _pocket2;
        }

        return null;
    }

    public void DropSpecialItem(Item itemToDrop, Vector3 posToDrop)
    {
        if (_dropIsAvailable)
        {
            if (SpecialItems.Contains(itemToDrop))
                SpecialItems.Remove(itemToDrop);

            var itemGameObject = itemToDrop.gameObject;

            posToDrop.z = itemToDrop.transform.position.z;
            itemGameObject.transform.position = posToDrop;
            itemGameObject.SetActive(true);

            StartCoroutine(StartDropCooldown());
        }
    }
    
    private IEnumerator StartDropCooldown()
    {
        _dropIsAvailable = false;
        yield return new WaitForSeconds(itemDropCooldown);
        _dropIsAvailable = true;
    }
}
