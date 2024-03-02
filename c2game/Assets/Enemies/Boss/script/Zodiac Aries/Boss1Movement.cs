using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Movement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x - player.transform.position.x < 0)
        {
            rb2D.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else
        {
            rb2D.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
}
