using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceCone : MonoBehaviour
{
    PolygonCollider2D polycoli;
    int Damage = 3;
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
            GameObject player = GameObject.Find("Player");
            other.GetComponent<PlayerMovement>().TakeDamage(Damage, transform.position.x - player.transform.position.x);
        }
    }
}
