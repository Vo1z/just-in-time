using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ObjectAttributes))]
public class ThrowableObjectController : MonoBehaviour
{
    [SerializeField] private float throwingForce = 5f;
    [Range(0, 3)]
    [SerializeField] private float boostUnderSpeedBuff = 1.5f;

    [SerializeField] private bool isActivateInvocableObjects = false;

    private PolygonCollider2D _polygonCollider2D;
    private BoxCollider2D _trigger;
    private Rigidbody2D _rigidbody2D;
    private ObjectAttributes _objectAttributes;
    
    private bool _isReadyToThrow = false;
    private GameObject _player;
    private PlayerAttributes _playerAttributes;

    private void Start()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
        _trigger = GetComponent<BoxCollider2D>();
        _player = GameController.SPlayer.Player;
        _playerAttributes = GameController.SPlayer.PlayerAttributes;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _objectAttributes = GetComponent<ObjectAttributes>();

        _trigger.isTrigger = true;
        
        Physics2D.IgnoreCollision(_polygonCollider2D, _player.GetComponent<Collider2D>());
    }

    private void Update()
    {
        // Debug.Log(_rigidbody2D.velocity);
        
        //Logic behind throwable object carrying
        if (_isReadyToThrow && _player != null)
        {
            var velocity = Vector3.zero;
            var itemPosition = _player.transform.position + GameController.SPlayer.PlayerEnvironmentInteraction.ThrowableItemOffset;

            transform.position = Vector3.SmoothDamp(transform.position, itemPosition, ref velocity, .01f);

            //Throwing logic
            if (Input.GetKey(KeyCode.RightControl))
            {
                _rigidbody2D.isKinematic = false;
                _isReadyToThrow = false;

                var boostedThrowingForce = _playerAttributes.IsUnderSpeedBoost ? throwingForce * boostUnderSpeedBuff : throwingForce;

                _rigidbody2D.AddForce(Vector3.right * (Mathf.Sign(_player.transform.localScale.x) * boostedThrowingForce), ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") && Input.GetKey(KeyCode.E))
        {
            _isReadyToThrow = true;
            _rigidbody2D.isKinematic = true;
            _rigidbody2D.angularVelocity = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var otherObjectAttributes = other.gameObject.GetComponent<ObjectAttributes>();
        var interactibleObject = other.gameObject.GetComponents<IInvocable>();
        
        if (isActivateInvocableObjects && interactibleObject.Length > 0)
            foreach (var invocable in interactibleObject)
                invocable.InvokeAction();
        
        if (otherObjectAttributes != null)
        {
            otherObjectAttributes.Hurt(_objectAttributes.Damage);
            _objectAttributes.Hurt(otherObjectAttributes.Damage * .5f);
        }
    }
}