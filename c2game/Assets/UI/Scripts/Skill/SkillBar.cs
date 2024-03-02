using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour
{
    public static SkillBar instance;
    public List<GameObject> objs = new List<GameObject>();
    public enum mode { swordmode, staffmode };
    public mode thismode;
    public List<Skill> skills = new List<Skill>();

    private List<float> deltatimes = new List<float>();
    private List<float> cooldowntimes = new List<float>();
    private List<float> starttimes = new List<float>();

    private List<Image> skillimages = new List<Image>();
    private List<Image> cooldownimages = new List<Image>();

    private void Awake()
    {
        if (instance != null)
            GameObject.Destroy(instance);
        instance = this;
        for(int i=0;i<4; i++)
        {
            cooldownimages.Add(objs[i].transform.Find("Fill").gameObject.GetComponent<Image>());
            skillimages.Add(objs[i].transform.Find("Image").gameObject.GetComponent<Image>());
        }
        for(int i=0;i<8;i++)
        {
            deltatimes.Add(0);
            cooldowntimes.Add(0);
            starttimes.Add(0);
        }
    }

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            int numhashed = i + 4 * (int)thismode;
            cooldownimages[i].sprite=skillimages[i].sprite = skills[numhashed].SkillImage;
        }
    }
    private void FixedUpdate()          //此设计下，只有在切换为对应装备时，cooldone才会更新
    {
        for(int i=0;i<4;i++)
        {
            updatecooldown(i);
        }
    }
    public void changemode()
    {
        thismode = (mode)(1 - (int)thismode);

        for (int i = 0; i < 4; i++)
        {
            int numhashed = i + 4 * (int)thismode;
            cooldownimages[i].sprite = skillimages[i].sprite = skills[numhashed].SkillImage;
            if (deltatimes[numhashed] == 0)
                cooldownimages[i].fillAmount = 0;
            if(deltatimes[numhashed]!=0)
            {
                starttimes[numhashed] = Time.time + deltatimes[numhashed] - cooldowntimes[numhashed];
            }
        }
    }

    public Skill useskill(int i)        //封装给player//传入按键的index，传出技能
    {
        int numhashed = i + 4 * (int)thismode;
        if (Player.instance.mana - skills[numhashed].manaconsumed < 0)
            return null;
        if(deltatimes[numhashed]==0)
        {
            Skill thisskill = skills[numhashed];
            deltatimes[numhashed]=cooldowntimes[numhashed] = thisskill.cooldown;
            starttimes[numhashed] = Time.time;
            cooldownimages[i].fillAmount = 1;
            //useskill(in playermovement)
            return thisskill;
        }
        return null;
    }
    private void updatecooldown(int i)//用于fixedupdate
    {
        int numhashed = i + 4 * (int)thismode;
        if (deltatimes[numhashed]!=0)
        {
            deltatimes[numhashed] = cooldowntimes[numhashed] - (Time.time-starttimes[numhashed]);
            if (deltatimes[numhashed] < 0)
                deltatimes[numhashed] = 0;
            cooldownimages[i].fillAmount = 1.0f / cooldowntimes[numhashed] * deltatimes[numhashed];
        }
    }

}
