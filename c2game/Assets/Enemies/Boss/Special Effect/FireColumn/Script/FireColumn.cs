using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireColumn: MonoBehaviour
{
    int damage = 2;
    PolygonCollider2D polycoli;
    // Start is called before the first frame update
    void Start()
    {
        polycoli = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().TakeDamage(damage,transform.position.x-Boss1Attack.player.transform.position.x);
        }
    }
    void banish()
    {
        Destroy(gameObject);
    }
}
