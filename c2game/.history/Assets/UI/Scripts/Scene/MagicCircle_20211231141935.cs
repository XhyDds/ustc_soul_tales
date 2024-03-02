using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicCircle : MonoBehaviour
{
    public bool isready;
    public int bossrelated;

    public GameObject magiccircle;
    public Animator animator;

    public GameObject loadingscene;

    public int targetindex;


    private void Start()
    {
        if(isready)
        {
            stimulate();
        }
        switch(bossrelated)
        {
            case 0:
                break;
            case 1:
                if (!Boss2.islive)
                    stimulate();
                    break;
            case 2:
                if (!Boss1.islive)
                    stimulate();
                    break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isready)
        {
            loadingscene.SetActive(true);
            loadingscene.GetComponent<Loading>().loadassignedscene(targetindex);
        }
    }

    public void stimulate()
    {
        isready = true;
        SpriteRenderer magicimage = magiccircle.GetComponent<SpriteRenderer>();
        Color color = new Color(255, 255, 255, 255);
        magicimage.color = color;
        animator.SetBool("isready", true);
    }
}
