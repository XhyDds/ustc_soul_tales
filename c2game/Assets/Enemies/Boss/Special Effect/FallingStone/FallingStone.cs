using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStone : MonoBehaviour
{
    public float speed = 10f;
    public float DestroyDistance = 500f;
    private Rigidbody2D rb2D;
    private Animator anim;
    public float distance;
    public int damage = 2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.up * -speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")||other.gameObject.CompareTag("Ground"))
        {
            if(other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<PlayerMovement>().TakeDamage(damage,transform.position.x-Boss1Attack.player.transform.position.x);
                rb2D.velocity = transform.position * 0;
            }
            Destroy(gameObject);
        }
    }
}
