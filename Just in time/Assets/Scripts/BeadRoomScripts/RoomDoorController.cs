using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class RoomDoorController : MonoBehaviour, IInvocable
{
   [SerializeField][NotNull] private GameObject lightGameObject;
    
    private Animator _animator;
    private Collider2D _collider2D;
    private Light2D _light;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
        _light = lightGameObject.GetComponent<Light2D>();
    }

    public void InvokeAction()
    {
        _animator.SetTrigger("OpenDoor");
        _collider2D.enabled = false;
        if(_light != null)
            _light.enabled = true;
    }
}