using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boss1Attack : MonoBehaviour
{
    public int Skill1Damage = 5;
    Animator anim;
    private CircleCollider2D circcoli;
    public static GameObject player;
    double time;
    public float deltaRadius = 0.4f;
    public float radius = 0.5f;
    public int num = 5;
    public GameObject fallingstone;
    GameObject fspoint;
    GameObject fs;
    public GameObject fireColumn;
    public GameObject fireBoom;
    Vector3 playerPos;
    int skillstype = 1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        time = Random.Range(2f, 3f);
        circcoli = GameObject.Find("attack").GetComponent<CircleCollider2D>();
        fspoint = GameObject.Find("FallingStonePoint");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time<=0)
        {
            if (player.transform.position.x - transform.position.x >= -5 && player.transform.position.x - transform.position.x <= 5)
                Attack1();
            else
                Attack2();
            time = Random.Range(5f, 7f);
        }
    }
    void Attack1()
    {
        anim.SetTrigger("skill1");
    }
    void Attack2()
    {
        anim.SetTrigger("skill2");
        playerPos = player.transform.position;
    }

    void Attack2_()
    {
        if(skillstype == 1)
        {
            Fallingstone();
        }
        else if(skillstype == 2)
        {
            FireColumn();
        }
        else
        {
            FireBoom() ;
        }
        ++skillstype;
        if (skillstype > 3)
            skillstype = 1;
    }
    void enable()
    {
        if (circcoli != null)
        {
            circcoli.enabled = true;
            circcoli.radius = radius;
        }
    }

    void disable()
    {
        if (circcoli != null)
            circcoli.enabled = false;
    }

    void enlarge()
    {
        circcoli.radius += deltaRadius;
    }

    void narrow()
    {
        circcoli.radius -= deltaRadius;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().TakeDamage(Skill1Damage,transform.position.x-player.transform.position.x);
        }
    }

    void Fallingstone()
    {
        int i;
        int j;
        for(i=0,j=-20;i<num;i++,j+=4)
        {
            Vector3 randPos = new Vector3(fspoint.transform.position.x + Random.Range((float)j, (float)(j+2)), fspoint.transform.position.y, fspoint.transform.position.z);
            fs=Instantiate(fallingstone, randPos, fallingstone.transform.rotation);
            float scale = Random.Range(0.2f, 0.4f);
            fs.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    void FireColumn()
    {
        Instantiate(fireColumn, playerPos + new Vector3(0, 1, 0), fireColumn.transform.rotation);
    }

    void FireBoom()
    {
        Instantiate(fireBoom, playerPos + new Vector3(0, 1, 0), fireBoom.transform.rotation);
    }
}
