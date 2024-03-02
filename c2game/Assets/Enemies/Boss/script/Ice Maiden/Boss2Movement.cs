using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Movement : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator anim;
    public Transform leftdownPos;
    public Transform rightupPos;
    Vector3 movePos;
    public float startWaitTime;
    float time;
    public float speed;
    public static bool attack=false;
    GameObject player;
    public static bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        movePos = GetRandomPos();
        player = GameObject.Find("Player");
        time = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > leftdownPos.transform.position.x && player.transform.position.x < rightupPos.position.x)
        {
            if (move)
                transform.position = Vector2.MoveTowards(transform.position, movePos, speed * Time.deltaTime);
            if (!attack && move && Vector2.Distance(movePos, transform.position) < 0.1f)
                if (time <= 0)
                {

                    movePos = GetRandomPos();
                    anim.SetBool("Move", true);
                    if (movePos.x - transform.position.x > 0)
                    {
                        transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                    time = startWaitTime;
                }
                else
                {
                    anim.SetBool("Move", false);
                    time -= Time.deltaTime;
                }
            else if (attack)
            {
                MoveToPlayer();
                if ((transform.position - player.transform.position).sqrMagnitude < 20)
                {
                    Boss2Attack.iceCone();
                    anim.SetBool("Move", false);
                    attack = false;
                    move = false;
                }
            }

        }

    }

    Vector2 GetRandomPos()
    {
        Vector2 RndPos = new Vector2(Random.Range(leftdownPos.position.x, rightupPos.position.x), Random.Range(leftdownPos.position.y, rightupPos.position.y));
        return RndPos;
    }

    private void MoveToPlayer()
    {
        if(move)
        {
            movePos = player.transform.position;
            anim.SetBool("Move", true);
            if (movePos.x - transform.position.x > 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

}
