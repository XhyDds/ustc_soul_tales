using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{

    public GameObject deathpanel;
    public GameObject loadingpanel;

    public Button returnbtn;
    public Button exitbtn;

    private void Awake()
    {
        returnbtn.onClick.AddListener(delegate { returnevent(); });
        exitbtn.onClick.AddListener(delegate { exitevent(); });
    }

    public void returnevent()
    {
        loadingpanel.SetActive(true);
        loadingpanel.GetComponent<Loading>().loadassignedscene();
        Player.instance.changehp(Player.instance.health_m);
        //´æµµ
        Time.timeScale = 1;
    }

    public void exitevent()
    {
        loadingpanel.SetActive(true);
        loadingpanel.GetComponent<Loading>().loadassignedscene(0);
        Player.instance.changehp(Player.instance.health_m);
        Time.timeScale = 1;
    }
}
