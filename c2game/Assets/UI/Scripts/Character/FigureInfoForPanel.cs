using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FigureInfoForPanel : MonoBehaviour
{

    private GameObject obj;
    public Text PlayerName;
    public Text PlayerLevel;
    public List<Text> texts = new List<Text>();
    private void OnEnable()
    {
        updateinfo();
    }

    void updateinfo()
    {
        obj = GameObject.FindWithTag("Player");
        PlayerName.text = obj.GetComponent<Player>().PlayerName;
        //updatelevel
        PlayerLevel.text = "level:" + obj.GetComponent<Player>().level;
        //updatedata
        //updatestrengh&defence
        texts[0].text = obj.GetComponent<Player>().strength.ToString();
        texts[1].text = obj.GetComponent<Player>().defence.ToString();
        //updatehp
        int hp = obj.GetComponent<Player>().health;
        int hp_m = obj.GetComponent<Player>().health_m;
        texts[2].text = hp + "/" + hp_m;
        //updatemp
        int mp = obj.GetComponent<Player>().mana;
        int mp_m = obj.GetComponent<Player>().mana_m;
        texts[3].text = mp + "/" + mp_m;
        //updateexp
        int exp = obj.GetComponent<Player>().exp;
        int exp_m = obj.GetComponent<Player>().exp_m;
        texts[4].text = exp + "/" + exp_m;
    }
}
