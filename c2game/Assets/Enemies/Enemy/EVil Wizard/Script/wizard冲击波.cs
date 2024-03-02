using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizard冲击波 : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 2;
    public float destroyDistance = 200f;
    private Rigidbody2D rb2D;
    public float distance;
    public GameObject weapon;
    private Animator anim;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.right * speed;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = (transform.position - WizardAttack.startPos).sqrMagnitude;
        if (distance > destroyDistance)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().TakeDamage(damage,transform.position.x-player.transform.position.x);
            anim.SetTrigger("ishit");
            rb2D.velocity = transform.right * 0;
        }
    }
    public void banish()
    {
        Destroy(gameObject);
    }
}
