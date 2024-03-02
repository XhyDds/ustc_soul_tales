using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Attack : MonoBehaviour
{
    float time;
    int skilltype = 1;
    static PolygonCollider2D[] polycoli = new PolygonCollider2D[6];
    static Animator anim;
    bool attack=false;
    public GameObject iceDragon;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        polycoli[0] = GameObject.Find("bone_16").GetComponent<PolygonCollider2D>();
        polycoli[1] = GameObject.Find("bone_17").GetComponent<PolygonCollider2D>();
        polycoli[2] = GameObject.Find("bone_18").GetComponent<PolygonCollider2D>();
        polycoli[3] = GameObject.Find("bone_19").GetComponent<PolygonCollider2D>();
        polycoli[4] = GameObject.Find("bone_20").GetComponent<PolygonCollider2D>();
        polycoli[5] = GameObject.Find("bone_21").GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        time = Random.Range(5f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!attack)
            time -= Time.deltaTime;
        if (!attack && time <= 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (skilltype == 1)
        {
            Boss2Movement.attack = true;
            attack = true;
            skilltype++;
        }
        else if (skilltype == 2)
        {
            IceDragon();
            Boss2Movement.move = false;
            skilltype++;
        }
        else if (skilltype == 3)
        {
            ;
            skilltype++;
        }
        else
        {
            ;
            skilltype++;
        }
        if (skilltype > 3)
            skilltype = 1;
    }

    static public void iceCone()
    {
        anim.SetTrigger("skill2");
    }

    public void enable()
    {
        int i;
        for (i = 0; i <= 5; i++)
        {
            polycoli[i].enabled = true;
        }
    }

    public void disable()
    {
        int i;
        for (i = 0; i <= 5; i++)
        {
            polycoli[i].enabled = false;
        }
    }

    public void endskill2()
    {
        Boss2Movement.move = true;
        time = Random.Range(5f, 7f);
        attack = false;
    }

    void IceDragon()
    {
        anim.SetTrigger("skill3");
        Instantiate(iceDragon,player.transform.position,iceDragon.transform.rotation);
    }
    
}
