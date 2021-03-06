using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>Script for displaying items from player's inventor's special pocket</summary>
public class SpecialItemDisplayScript : MonoBehaviour
{
    [SerializeField] private float spacing = 5f;
    
    private float _currentOffset;
    
    private GameObject _parentCanvas;

    private PlayerInventory _playerInventory;
    private List<Item> _specialItems;
    private List<GameObject> _icons = new List<GameObject>();

    void Start()
    {
        _playerInventory = GameController.SPlayer.PlayerInventory;
        _specialItems = _playerInventory.SpecialItems;
        _parentCanvas = transform.parent.gameObject;
        
        GetComponent<Image>().enabled = false;
    }

    private void LateUpdate()
    {
        if (_icons.Count != _specialItems.Count)
        {
            foreach (var icon in _icons)
                Destroy(icon);
            _icons.Clear();
            _currentOffset = 0;

            foreach (var item in _specialItems)
            {
                var newIcon = new GameObject();
                var image = newIcon.AddComponent<Image>();
                var iconScale = newIcon.transform.localScale;
                image.sprite = item.InterfaceSprite;
                image.GetComponent<RectTransform>().sizeDelta = item.ImageSize;

                newIcon.transform.position = transform.position + Vector3.down * _currentOffset;
                newIcon.transform.SetParent(_parentCanvas.transform);
                newIcon.transform.localScale = iconScale;
                
                _icons.Add(newIcon);
                
                _currentOffset += spacing;
            }
        }
    }
}
