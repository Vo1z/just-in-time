using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
