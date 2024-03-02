using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurricane : MonoBehaviour
{
    private Rigidbody2D rb2D;

    public Skill thisskill;

    public float destroyTime = 10f;
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            int damage= (int)(thisskill.multiple / 100f * (Player.instance.strength - other.GetComponent<EnemyGeneral>().defence));
            other.GetComponent<EnemyGeneral>().TakeDamage(damage);
        }
    }
}
