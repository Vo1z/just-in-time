using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ConsumablesDisplayScript : MonoBehaviour
{
    [SerializeField] private float offset = 5f;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private string itemTag = "SpeedBooster";
    
    private GameObject _parentCanvas;
    private Image _startImage;
    private PlayerInventory _playerInventory;
    
    private List<GameObject> _speedBoosters = new List<GameObject>();
    private void Start()
    {
        _parentCanvas = transform.parent.gameObject;
        _startImage = GetComponent<Image>();
        _playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();

        _startImage.enabled = false;
    }

    void Update()
    {
        if (!CompareLists(_speedBoosters, _playerInventory.GetItemsByTag(itemTag)))
        {
            for (var i = 0; i < _speedBoosters.Count; i++)
            {
                _speedBoosters[i].transform.position = transform.position + Vector3.right * (i * offset);
            }
        }
    }

    private bool CompareLists(List<GameObject> localList, List<GameObject> commonList)
    {
        if (localList.Count() < commonList.Count())
        {
            var newIcon = new GameObject();
            var image = newIcon.AddComponent<Image>();
            image.sprite = _startImage.sprite;
            image.rectTransform.sizeDelta = _startImage.rectTransform.sizeDelta;
            newIcon.transform.SetParent(_parentCanvas.transform);
            newIcon.SetActive(true);

            localList.Add(newIcon);

            return false;
        }
        if (localList.Count() > commonList.Count())
        {
            var iconToRemove = localList[localList.Count - 1];
            localList.RemoveAt(localList.Count - 1);
            Destroy(iconToRemove);
            
            return false;
        }

        return true;
    }
}
