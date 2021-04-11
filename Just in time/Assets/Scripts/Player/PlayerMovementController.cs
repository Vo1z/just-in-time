using UnityEngine;


///<sumary>Class for handling player movement</sumary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAttributes))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody;
    private PlayerAttributes _playerAttributes;
    private Animator _playerAnimator;
    private Collider2D _playerCollider2D;
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _playerAttributes = GetComponent<PlayerAttributes>();
        _playerAnimator = GetComponent<Animator>();
        _playerCollider2D = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        float xDelta = Input.GetAxis("Horizontal") * _playerAttributes.Speed;
        Vector2 movement = new Vector2(xDelta * Time.deltaTime, _playerRigidBody.velocity.y);
        
        //Rotates player in the direction of movement
        if(xDelta < 0 && transform.localScale.x > 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        if(xDelta > 0 && transform.localScale.x < 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        
        _playerAnimator.SetFloat("Speed", Mathf.Abs(xDelta));
        _playerRigidBody.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) 
            _playerRigidBody.AddForce(Vector2.up * _playerAttributes.JumpForce, ForceMode2D.Impulse);
            
    }

    private bool IsGrounded()
    {
        Vector2 min = _playerCollider2D.bounds.min;
        Vector2 max = _playerCollider2D.bounds.max;
        max.x -= .5f;
        max.y = min.y - .1f;
        min.y -= .15f;
        min.x += .5f;
        
        Collider2D hit = Physics2D.OverlapArea(min, max);
        
        return hit != null;
    }
}