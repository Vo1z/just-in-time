using UnityEngine;

///<sumary>
/// Script(mainly for camera) that makes game object(to which this script is attached)
/// smoothly follow referenced game object
/// </sumary>
[RequireComponent(typeof(Camera))]
public class CharacterFollower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject player;
    
    [Header("Variables")]
    [SerializeField] private float transferSpeed = .05f;


    private Vector3 _cameraOffset;
    void Start()
    {
        _cameraOffset = transform.position - player.transform.position;
    }
    
    void Update()
    {
        var position = transform.position;
        Vector3 targetPosition = player.transform.position + _cameraOffset;
        targetPosition.z = position.z;
        
        var velocity = Vector3.zero;
        position = Vector3.SmoothDamp(position, targetPosition,
            ref velocity, transferSpeed);
        transform.position = position;
    }
}
