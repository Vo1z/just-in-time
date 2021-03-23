using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField][Range(0, 10)]
    private int maxNumberOfItems = 5;

    public string[] itemTags = {"SpecialItem", "SpeedBooster", "HpRegenerator"};

    private List<GameObject> _specialItems = new List<GameObject>();
    private List<GameObject> _speedBoosters = new List<GameObject>();
    private List<GameObject> _hpRegenerators = new List<GameObject>();

    private Dictionary<string, List<GameObject>> _pockets = new Dictionary<string, List<GameObject>>();

    private void Start()
    {
        _pockets.Add(itemTags[0], _specialItems);
        _pockets.Add(itemTags[1], _speedBoosters);
        _pockets.Add(itemTags[2], _hpRegenerators);
    }

    public bool AddItem(GameObject item) 
    {
        var totalNumberOfItems = _specialItems.Count + _speedBoosters.Count + _hpRegenerators.Count;
        if (itemTags.Contains(item.tag) && totalNumberOfItems <= maxNumberOfItems)
        {
            _pockets[item.tag].Add(item);
        }

        return false;
    }

    public void RemoveItem(GameObject item)
    {
        _pockets[item.tag].Remove(item);
    }

    public List<GameObject> GetItemsByTag(string pocketTag)
    {
        return _pockets[pocketTag];
    }
    
    public GameObject GetFirstItemInGivenPocket(string pocketTag)
    {
        var itemList = _pockets[pocketTag];
        
        if(itemList.Count > 0)
            return itemList[0];
        
        return null;
    }
}
