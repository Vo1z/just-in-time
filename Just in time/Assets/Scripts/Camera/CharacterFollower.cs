using UnityEngine;

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
        var pos = player.transform.position;

        _cameraOffset = transform.position - pos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.transform.position + _cameraOffset;
        targetPosition.z = transform.position.z;
        
        var velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
            ref velocity, transferSpeed);
    }
}
