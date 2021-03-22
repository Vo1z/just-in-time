using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAttributes))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private PlayerAttributes _playerAttributes;
    private Animator _animator;
    private BoxCollider2D _boxCollider2D;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerAttributes = GetComponent<PlayerAttributes>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDelta = Input.GetAxis("Horizontal") * _playerAttributes.Speed;
        Vector2 movement = new Vector2(xDelta * Time.deltaTime, _rigidBody.velocity.y);
        
        //Rotates player in the direction of movement
        if(xDelta < 0 && transform.localScale.x > 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        if(xDelta > 0 && transform.localScale.x < 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        
        _animator.SetFloat("Speed", Mathf.Abs(xDelta));
        _rigidBody.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) 
            _rigidBody.AddForce(Vector2.up * _playerAttributes.JumpForce, ForceMode2D.Impulse);
            
    }

    private bool IsGrounded()
    {
        Vector2 min = _boxCollider2D.bounds.min;
        Vector2 max = _boxCollider2D.bounds.max;
        max.x -= .5f;
        max.y = min.y - .1f;
        min.y -= .15f;
        min.x += .5f;
        
        Collider2D hit = Physics2D.OverlapArea(min, max);
        
        return hit != null;
    }
}