using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using UnityEngine.U2D.Animation;


public class Player : MonoBehaviour
{
    public static Player instance;

    //交互
    public GameObject textbox1;
    public GameObject textbox2;

    //基本信息
    [Header("Info")]
    //public int PlayerNum;
    public string PlayerName;
    //数据
    public int health , health_m , mana , mana_m ;
    public int exp , exp_m , level ;
    public LevelRule playerlevelrule;
    public int strength , defence ;
    public int basic_strength ;
    //武器与技能
    [Header("weapon")]
    public Item thisweapon;
    public enum mode { swordmode, staffmode };
    public mode thismode = mode.swordmode;
    private bool isshadowing;


    private void Awake()
    {
        if (instance != null)
            GameObject.Destroy(instance);
        instance = this;

        //存档
        StartCoroutine(save_wait());
    }
    public IEnumerator save_wait()
    {
        yield return SaveFunction.instance;
        if (MainMenu.isnewgame == true)
        {
            newgame();
            SaveFunction.instance.savegame();
            
        SaveFunction.instance.loadgame();
            textbox1.SetActive(false);
        }
        else if(!Boss2.islive)
        {
          textbox2.SetActive(false);
        }
        SaveFunction.instance.loadgame();
        StartCoroutine(newgame_wait());
    }
    private void Start()
    {
        StartCoroutine(initbar_wait());
        MainMenu.ismenu = false;

        Sound.instance.audiosource.volume = SettingPanel.volume;
    }

    IEnumerator newgame_wait()
    {
        yield return TaskManager.instance;
        MainMenu.isnewgame = false;

        StartCoroutine(initbar_wait());
    }
    IEnumerator initbar_wait()
    {
        yield return FigureInfoForBar.instance;

        FigureInfoForBar.instance.init();

    }
    //存档
    public void newgame()
    {
        PlayerName = "Dds";
        health = health_m = 200;
        mana = mana_m = 200;
        exp = 0; exp_m = 100;
        level = 1;
        strength = basic_strength = 10;
        defence = 5;

        textbox1.SetActive(true);
    }
    public Save CreateSaveGameobject()
    {

        Save save = new Save();

        save.PlayerName = PlayerName;

        save.health = health;
        save.health_m = health_m;
        save.mana = mana;
        save.mana_m = mana_m;

        save.exp = exp;
        save.exp_m = exp_m;
        save.level = level;

        save.strength = strength;
        save.defence = defence;
        save.basic_strength = basic_strength;
        //save.thisweapon = thisweapon;

        /*save.mymoney = this.transform.parent.GetComponentInChildren<MyBag>().mymoney;
        foreach (var item in this.transform.parent.GetComponentInChildren<MyBag>().weaponsinbag)
        {
            save.addweapon(item.item, item.num);
        }
        foreach (var item in this.transform.parent.GetComponentInChildren<MyBag>().consumablesinbag)
        {
            save.addconsumable(item.item, item.num);
        }
        foreach (var item in this.transform.parent.GetComponentInChildren<MyBag>().propertiesinbag)
        {
            save.addproperty(item.item, item.num);
        }*/

        MyBag.instance.savebag(save);
        TaskManager.instance.savetask(save);

        return save;
    }
    public void LoadSaveGameobject(Save save)
    {
        PlayerName = save.PlayerName;

        health = save.health;
        health_m = save.health_m;
        mana = save.mana;
        mana_m = save.mana_m;

        exp = save.exp;
        exp_m = save.exp_m;
        level = save.level;

        strength = save.strength;
        defence = save.defence;
        basic_strength = save.basic_strength;
        //thisweapon = save.thisweapon;

        MyBag.instance.loadbag(save);
        TaskManager.instance.loadtask(save);
    }
    //data变化
    public int changehp(int delta)
    {
        health = health + delta;
        if (health < 0)

            if (health < 0)
            {
                health = 0;
                return -1;      //死亡
            }
        if (health > health_m)
        {
            health = health_m;
        }

        FigureInfoForBar.instance.updatehp();

        return health;
    }
    public void getexp(int expgotten)
    {
        exp += expgotten;
        while (exp >= exp_m)
        {
            exp -= exp_m;
            levelup();
        }

        FigureInfoForBar.instance.updateexp();

    }
    private void levelup()
    {
        level++;

        exp_m = (int)(exp_m * playerlevelrule.mutiple[0]);

        health = health_m += playerlevelrule.delta[0];
        mana = mana_m += playerlevelrule.delta[1];
        strength += playerlevelrule.delta[2];
        basic_strength += playerlevelrule.delta[2];
        defence += playerlevelrule.delta[3];

        FigureInfoForBar.instance.updatehp();
        FigureInfoForBar.instance.updatemp();
        FigureInfoForBar.instance.updateexp();
    }

    public Skill useskill(int i)       //-1代表失败//传入按键index//封装给skill
    {
        Skill skill=SkillBar.instance.useskill(i);
        if (skill == null)
            return null;

        mana -= skill.manaconsumed;
        FigureInfoForBar.instance.updatemp();

        return skill;
    }
    //换装
    public void changecostume(Costume costume)
    {
        foreach (var resolver in FindObjectsOfType<SpriteResolver>())
        {
            resolver.SetCategoryAndLabel(resolver.GetCategory(), costume.CostumeName);
        }
    }
    public void changeweapon(Item weapon)
    {
        //changeimage
        GameObject.Find("weapon").GetComponent<SpriteResolver>().SetCategoryAndLabel("Weapon", weapon.ItemName);
        //changedata
        mode premode = (mode)(weapon.thismode);
        strength = basic_strength + weapon.data;
        thisweapon = weapon;

        if (premode != thismode)
        {
            thismode = premode;
            SkillBar.instance.changemode();
        }

    }
    //动画事件
    /*public void flash1()
    {
        GameObject flash1obj = GameObject.Find("flash1");
        Animator flash1 = flash1obj.GetComponent<Animator>();
        flash1.Play("flash1");
    }
    public void flash2()
    {
        GameObject flash2obj = GameObject.Find("flash2");
        Animator flash2 = flash2obj.GetComponent<Animator>();
        flash2.Play("flash2");
    }
    private void shadowing()
    {
        if (isshadowing == true)
            ShadowPool.instance.getfrompool();
    }
    public void shadowingstart()
    {
        isshadowing = true;
    }
    public void shaowingfinish()
    {
        isshadowing = false;
    }*/
}
