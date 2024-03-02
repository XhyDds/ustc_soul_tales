using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyBless : MonoBehaviour
{
    public Skill thisskill;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    public void addHp()
    {
        int hpPlus = (int)(thisskill.multiple / 100f*Player.instance.strength);
        Player.instance.changehp(hpPlus);
    }
}
