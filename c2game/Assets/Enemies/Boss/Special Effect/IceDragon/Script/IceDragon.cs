using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDragon : MonoBehaviour
{
    BoxCollider2D boxcoli;
    int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        boxcoli = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void disable()
    {
        boxcoli.enabled = false;
    }

    void destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().TakeDamage(damage,transform.position.x-other.GetComponent<Transform>().position.x);
        }
    }
}
