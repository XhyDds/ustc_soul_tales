using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    public float normalSpeed=2f;
    public float chaseSpeed=3f;
    public Rigidbody2D rb2D;
    public Animator anim;
    public float distance;
    public float x;
    public float StartWaitTime = 1f;
    public float WaitTime=0f;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        distance = Vector2.Distance(player.transform.position,this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x-player.transform.position.x > 5&& this.transform.position.x - player.transform.position.x < 11)
        {
            rb2D.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            anim.SetBool("Move", true);
            Vector3 movement = new Vector3(-1, 0, 0);
            rb2D.transform.position += movement * chaseSpeed * Time.deltaTime;
        }
        else if(this.transform.position.x - player.transform.position.x < -5 && this.transform.position.x - player.transform.position.x > -11)
        {
            rb2D.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            anim.SetBool("Move", true);
            Vector3 movement = new Vector3(1, 0, 0);
            rb2D.transform.position += movement * chaseSpeed * Time.deltaTime;
        }
        else if(this.transform.position.x - player.transform.position.x > -5 && this.transform.position.x - player.transform.position.x < 5)
        {
            anim.SetBool("Move", false);
            if(this.transform.position.x - player.transform.position.x<0)
            {
                rb2D.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else
            {
                rb2D.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
        else
        {
            if (WaitTime < 0.01f)
            {
                Getdirection();
                WaitTime = StartWaitTime;
            }
            else
            {
                if (x > 0.01f)
                {
                    rb2D.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    anim.SetBool("Move", true);
                    Vector3 movement = new Vector3(1, 0, 0);
                    rb2D.transform.position += movement * normalSpeed * Time.deltaTime;
                    WaitTime -= Time.deltaTime;
                }
                else if(x < -0.01f)
                {
                    rb2D.transform.eulerAngles = new Vector3(0f, 180f, 0f);
                    anim.SetBool("Move", true);
                    Vector3 movement = new Vector3(-1, 0, 0);
                    rb2D.transform.position += movement * normalSpeed * Time.deltaTime;
                    WaitTime -= Time.deltaTime;
                }
                else
                {
                    anim.SetBool("Move", false);
                    WaitTime -= Time.deltaTime;
                }
            }
        }
    }
    void Getdirection()
    {
        x = Random.Range(-1f, 1f);
        if(x > 0.33f)
        {
            x = 1f; 
        }
        else if(x < -0.33f)
        {
            x = -1f;
        }
        else
        {
            x = 0f;
        }
        return;
    }
}
