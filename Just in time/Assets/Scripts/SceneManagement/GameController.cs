using UnityEngine;

public class GameController : MonoBehaviour
{
    public struct SPlayer
    {
        public static GameObject Player { get; internal set; }
        public static PlayerAttributes PlayerAttributes { get; internal set; }
        public static PlayerInventory PlayerInventory { get; internal set; }
        public static PlayerInventoryController PlayerInventoryController { get; internal set; }
        public static PlayerEnvironmentInteraction PlayerEnvironmentInteraction { get; internal set; }
        
    }
    
    void Awake()
    {
        SPlayer.Player = GameObject.FindWithTag("Player");
        SPlayer.PlayerAttributes = SPlayer.Player.GetComponent<PlayerAttributes>();
        SPlayer.PlayerInventory = SPlayer.Player.GetComponent<PlayerInventory>();
        SPlayer.PlayerInventoryController = SPlayer.Player.GetComponent<PlayerInventoryController>();
        SPlayer. PlayerEnvironmentInteraction = SPlayer.Player.GetComponent<PlayerEnvironmentInteraction>();
    }
}
