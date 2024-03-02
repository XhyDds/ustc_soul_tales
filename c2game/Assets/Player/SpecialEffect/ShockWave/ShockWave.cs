using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{

    public float speed = 10f;
    public float destroyDistance = 200f;
    private Rigidbody2D rb2D;
    public float distance;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        distance = (transform.position - MagicAttack.startPos).sqrMagnitude;
        if (distance > destroyDistance)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            int damage = (int)((Player.instance.strength - other.GetComponent<EnemyGeneral>().defence));
            other.GetComponent<EnemyGeneral>().TakeDamage(damage);
            anim.SetTrigger("ishit");
            rb2D.velocity = transform.right * 0;
        }
    }
    public void banish()
    {
        Destroy(gameObject);
    }
}
