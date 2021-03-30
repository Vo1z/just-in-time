using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ConsumablesDisplayScript : MonoBehaviour
{
    [SerializeField] private float spacing = 5f;
    [SerializeField] private PlayerInventory.Pocket pocket = PlayerInventory.Pocket.Pocket1;

    private float _currentOffset;
    
    private GameObject _parentCanvas;
    private Image _startImage;
    
    private Stack<ConsumableItem> _pocketWithConsumables;
    private Stack<GameObject> _icons = new Stack<GameObject>();

    private void Start()
    {
        _parentCanvas = transform.parent.gameObject;
        _pocketWithConsumables = GameController.SPlayer.PlayerInventory.GetPocket(pocket);
        
        GetComponent<Image>().enabled = false;
    }

    void Update()
    {
        if (_icons.Count != _pocketWithConsumables.Count)
        {
            foreach (var icon in _icons)
                Destroy(icon);
            _icons.Clear();
            _currentOffset = 0;

            foreach (var item in _pocketWithConsumables)
            {
                var newIcon = new GameObject();
                var image = newIcon.AddComponent<Image>();
                var iconScale = newIcon.transform.localScale;
                image.sprite = item.InterfaceSprite;
                image.GetComponent<RectTransform>().sizeDelta = item.ImageSize;

                newIcon.transform.position = transform.position + Vector3.down * _currentOffset;
                newIcon.transform.SetParent(_parentCanvas.transform);
                newIcon.transform.localScale = iconScale;
                
                _icons.Push(newIcon);
                
                _currentOffset += spacing;
            }
        }
    }
}