using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FigureInfoForBar : MonoBehaviour
{
    public static FigureInfoForBar instance;

    private GameObject obj;
    public Text PlayerName;
    public Text PlayerLevel;
    public List<Slider> sliders = new List<Slider>();
    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        obj = GameObject.FindWithTag("Player");

        init();
    }

    public void init()
    {
        PlayerName.text = obj.GetComponent<Player>().PlayerName;
        updatehp();
        updatemp();
        updateexp();
    }

    public void updatehp()
    {
        //updatehp
        float hp = obj.GetComponent<Player>().health;
        float hp_m = obj.GetComponent<Player>().health_m;
        sliders[0].value = hp / hp_m;
        sliders[0].GetComponentInChildren<Text>().text = "hp:" + hp / hp_m * 100 + "%";
    }
    public void updatemp()
    {
        //updatemp
        float mp = obj.GetComponent<Player>().mana;
        float mp_m = obj.GetComponent<Player>().mana_m;
        sliders[1].value = mp / mp_m;
        sliders[1].GetComponentInChildren<Text>().text = "mp:" + mp / mp_m * 100 + "%";
    }
    public void updateexp()
    {
        //updateexp
        float exp = obj.GetComponent<Player>().exp;
        float exp_m = obj.GetComponent<Player>().exp_m;
        sliders[2].value = exp / exp_m;
        sliders[2].GetComponentInChildren<Text>().text = "exp:" + exp / exp_m * 100 + "%";
        //updatelevel
        PlayerLevel.text = obj.GetComponent<Player>().level + " L";
    }
}
