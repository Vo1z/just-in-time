using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CharacterFollower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject player;
    
    [Header("Variables")]
    [SerializeField] private float transferSpeed = 50f;
    
    void Start()
    {
        var pos = player.transform.position;

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z); 
        
        var velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
            ref velocity, transferSpeed);
    }
}
