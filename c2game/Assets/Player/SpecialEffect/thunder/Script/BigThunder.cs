using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigThunder : MonoBehaviour
{
    public Skill thisskill;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            int damage = (int)(thisskill.multiple / 100f * (Player.instance.strength - other.GetComponent<EnemyGeneral>().defence));
            other.GetComponent<EnemyGeneral>().TakeDamage(damage);
        }
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
