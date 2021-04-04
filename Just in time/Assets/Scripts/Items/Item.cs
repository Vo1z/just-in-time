using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class Item : MonoBehaviour
{
    [Header("UI options")]
    [SerializeField] private Vector2 imageSize = new Vector2(50, 50);

    protected PlayerInventory _playerInventory;
    protected Sprite _interfaceSprite;

    public Sprite InterfaceSprite => _interfaceSprite;
    public Vector2 ImageSize => imageSize;

    protected void Start()
    {
        _playerInventory = GameController.SPlayer.PlayerInventory;
        _interfaceSprite = GetComponent<SpriteRenderer>().sprite;
        GetComponent<Collider2D>().isTrigger = true;
        
        if (_interfaceSprite == null)
            throw new NullReferenceException($"Sprite is missing at {gameObject.name}");
        gameObject.tag = "Item";
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && Input.GetKey(KeyCode.E)) 
            _playerInventory.AddItem(this, false);
    }
}
