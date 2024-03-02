using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfoForBar : MonoBehaviour
{
    public Enemy thisenemy;
    public GameObject obj;

    public Slider slider;

    public Text bossname;
    public Image bossimage;

    public void updatehp()
    {
        float hp = obj.GetComponent<EnemyGeneral>().hp;
        float hp_m = obj.GetComponent<EnemyGeneral>().hp_m;
        slider.value = hp / hp_m;
    }
}
