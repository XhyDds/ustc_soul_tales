using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    //��ֵ
    public string PlayerName;
    public int health, health_m, mana, mana_m;
    public int exp, exp_m, level;

    public int strength, defence;
    public int basic_strength;
    //public Item thisweapon;

    //游戏进度
    public bool isnewgame;
    public bool gameover;
    public bool isboss1alive;
    public bool isboss2alive;

    //����
    public int mymoney;
    [System.Serializable]
    public struct iteminbag
    {
        public string itemname;
        public int num;
    }
    public List<iteminbag> weaponsinbag = new List<iteminbag>();
    public List<iteminbag> consumablesinbag = new List<iteminbag>();
    public List<iteminbag> propertiesinbag = new List<iteminbag>();
    public List<iteminbag> costumesinbag = new List<iteminbag>();

    
    public void addweapon(string item,int num)
    {
        iteminbag oneitem = new iteminbag();
        oneitem.itemname = item;
        oneitem.num = num;
        weaponsinbag.Add(oneitem);
    }
    public void addconsumable(string item, int num)
    {
        iteminbag oneitem = new iteminbag();
        oneitem.itemname = item;
        oneitem.num = num;
        consumablesinbag.Add(oneitem);
    }
    public void addproperty(string item, int num)
    {
        iteminbag oneitem = new iteminbag();
        oneitem.itemname = item;
        oneitem.num = num;
        propertiesinbag.Add(oneitem);
    }

    public void addcostume(string item, int num)
    {
        iteminbag oneitem = new iteminbag();
        oneitem.itemname = item;
        oneitem.num = num;
        costumesinbag.Add(oneitem);
    }

    //����
    [System.Serializable]
    public struct ingtask
    {
        public int thistaskindex;
        public bool isfinished;
    }

    public List<ingtask> tasks_ing = new List<ingtask>();
    public List<int> tasks_unstart = new List<int>();
    public List<int> tasks_ended = new List<int>();

    public void addingtask(int taskindex,bool isfinished)
    {
        ingtask thistask;
        thistask.thistaskindex = taskindex;
        thistask.isfinished = isfinished;
        tasks_ing.Add(thistask);
    }

}
