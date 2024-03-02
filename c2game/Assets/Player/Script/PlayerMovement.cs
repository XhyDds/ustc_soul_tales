using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MoveRule moveRule;

    public float jumpVelocity ;
    public float fallMutiplier ;
    public float lowJumpMultiplier ;
    public bool Jumprequest = false;
    public float speed ;

    private SpriteRenderer Sr;
    private Rigidbody2D _rigidbody;
    static public Animator _animator;
    public float x;
    public float y;
    public float flashTime = 0.25f;
    public float time = 1;
    public static bool canMove = true;
    Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        jumpVelocity = moveRule.jumpVelocity;
        fallMutiplier = moveRule.fallMutiplier;
        lowJumpMultiplier = moveRule.lowJumpMultiplier;
        speed = moveRule.speed;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if(canMove)
        {
            if (Input.GetButton("Jump") && (_rigidbody.velocity.y < 0.001f && _rigidbody.velocity.y > -0.001f))
            {
                Jumprequest = true;
            }
            if (x > 0)
            {
                _rigidbody.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                _animator.SetBool("Run", true);
            }
            if (x < 0)
            {
                _rigidbody.transform.eulerAngles = new Vector3(0f, 180f, 0f);
                _animator.SetBool("Run", true);
            }
            if (x < 0.001f && x > -0.001f)
            {
                _animator.SetBool("Run", false);
            }
            if (_rigidbody.velocity.y < 0.01f && _rigidbody.velocity.y > -0.01f)
            {
                _animator.SetInteger("Jump", 0);
            }
            else
            {
                _animator.SetInteger("Jump", 1);
            }
            if (PlayerAttack.attack == false || _rigidbody.velocity.y > 0.01f || _rigidbody.velocity.y < -0.01f)
                Run();
            
        }
    }

    private void FixedUpdate()
    {
        if(canMove)
        {
            if (Jumprequest)
            {
                _rigidbody.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
                Jumprequest = false;
            }
            if (_rigidbody.velocity.y < 0)
            {
                _rigidbody.gravityScale = fallMutiplier;
            }
            else if (_rigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                _rigidbody.gravityScale = lowJumpMultiplier;
            }
            else
            {
                _rigidbody.gravityScale = 1f;
            }
        }
    }
    private void Run()
    {
        Vector3 movement = new Vector3(x, 0, 0);
        _rigidbody.transform.position += movement * speed * Time.deltaTime;
    }

    public void TakeDamage(int damage,float distance)
    {
        if (Player.instance.changehp(-damage) > 0)
        {
            _animator.SetTrigger("GotHit");
            if (distance > 0)
                _rigidbody.transform.eulerAngles = new Vector3(0, 0, 0);
            else
                _rigidbody.transform.eulerAngles = new Vector3(0, 180, 0);
            Vector3 forceDirection = new Vector3(distance > 0 ? -1 : 1, 1, 0);
            _rigidbody.AddForce(forceDirection, ForceMode2D.Impulse);
        }
        else
            StartCoroutine(Destr());
    }

    IEnumerator Destr()
    {
        _animator.SetTrigger("Death");
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    
}
