using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    CapsuleCollider2D capcoli;
    float DestoryTime = 5f;
    GameObject player;
    public float smoothing;

    public Skill thisskill;
    // Start is called before the first frame update
    void Start()
    {
        capcoli = GetComponent<CapsuleCollider2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        DestoryTime -= Time.deltaTime;
        if (DestoryTime <= 0)
            Destroy(gameObject);
        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, 2, 0), smoothing);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            int damage = (int)(thisskill.multiple / 100f * (Player.instance.strength - other.GetComponent<EnemyGeneral>().defence));
            other.GetComponent<EnemyGeneral>().»÷·É(transform.position.x - other.GetComponent<Transform>().position.x, 5);
            other.GetComponent<EnemyGeneral>().TakeDamage(damage);
        }
    }


}
