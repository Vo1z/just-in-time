using UnityEngine;
using UnityEngine.UI;

///<summary>Script that displays number of free slots in inventory</summary>
[RequireComponent(typeof(Text))]
public class NumberOfItemsDisplayer : MonoBehaviour
{
    private Text _text;
    private string _originalContent;
    private PlayerInventory _playerInventory;

    private void Start()
    {
        _text = GetComponent<Text>();
        _originalContent = _text.text;
        _playerInventory = GameController.SPlayer.PlayerInventory;
    }

    private void Update()
    {
        _text.text = $"{_originalContent}{_playerInventory.CurrentNumberOfItems}/{_playerInventory.MaxNumberOfItems}";
    }
}
