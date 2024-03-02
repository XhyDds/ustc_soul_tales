using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : MonoBehaviour
{
    int damage=2;
    float attackInterval=3f;
    float waitTime;
    private Animator anim;
    static public Vector3 startPos;
    public GameObject cjbprefab;
    public GameObject player;
    private PolygonCollider2D polycoli;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = attackInterval;
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        polycoli = gameObject.GetComponentInChildren<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime<=0)
        {
            if(player.transform.position.x-transform.position.x<=5&& player.transform.position.x - transform.position.x>=-5)
            attack();
            waitTime = attackInterval;
        }
        waitTime -= Time.deltaTime;
    }

    void attack()
    {
        anim.SetTrigger("Attack");
    }
    public void enableHitbox()
    {
        if (polycoli != null)
            polycoli.enabled = true;
    }

    public void disableHitbox()
    {
        if(polycoli != null)
            polycoli.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().TakeDamage(damage,transform.position.x-player.transform.position.x);
        }
    }

    /*public void attack()
    {
        startPos = transform.position;
        Instantiate(cjbprefab, transform.position, transform.rotation);
    }*/
}
