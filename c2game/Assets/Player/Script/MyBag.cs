using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//内嵌类（调用于BagManager和SaveFunction）

public class MyBag : MonoBehaviour
{
    public static MyBag instance;

    private int itemnum;

    public int mymoney;

    public struct iteminbag
    {
        public Item item;
        public int num;
    }

    public List<iteminbag> weaponsinbag = new List<iteminbag>();
    public List<iteminbag> consumablesinbag = new List<iteminbag>();
    public List<iteminbag> propertiesinbag = new List<iteminbag>();
    public List<iteminbag> costumesinbag = new List<iteminbag>();

    private void Awake()
    {
        if (instance != null)
            GameObject.Destroy(instance);
        instance = this;
    }

    public void createitem(Item item, int num = 1)       // 保证可以成功才调用
    {
        iteminbag newitem = new iteminbag();
        newitem.item = item;
        newitem.num = num;
        switch (item.thismode)
        {
            case Item.mode.sword:
            case Item.mode.staff:
                weaponsinbag.Add(newitem);
                break;
            case Item.mode.consumable:
                consumablesinbag.Add(newitem);
                break;
            case Item.mode.property:
                propertiesinbag.Add(newitem);
                break;
            case Item.mode.costume:
                costumesinbag.Add(newitem);
                break;
        }
        itemnum++;
    }

    public void edititem(Item item, int num)              //已保证在背包中
    {
        for (int i = 0; i < weaponsinbag.Count; i++)
        {
            iteminbag iteminbag = weaponsinbag[i];
            if (item.ItemName == iteminbag.item.ItemName)
            {
                iteminbag.num += num;

                if (iteminbag.num == 0)
                {
                    weaponsinbag.Remove(iteminbag);
                    itemnum--;
                    break;
                }

            }
        }

        for (int i = 0; i < consumablesinbag.Count; i++)
        {
            iteminbag iteminbag = consumablesinbag[i];
            if (item.ItemName == iteminbag.item.ItemName)
            {
                iteminbag.num += num;

                if (iteminbag.num == 0)
                {
                    consumablesinbag.Remove(iteminbag);
                    itemnum--;
                    break;
                }

            }
        }

        for (int i = 0; i < propertiesinbag.Count; i++)
        {
            iteminbag iteminbag = propertiesinbag[i];
            if (item.ItemName == iteminbag.item.ItemName)
            {
                iteminbag.num += num;

                if (iteminbag.num == 0)
                {
                    propertiesinbag.Remove(iteminbag);
                    itemnum--;
                    break;
                }

            }
        }
        for (int i = 0; i < costumesinbag.Count; i++)
        {
            iteminbag iteminbag = costumesinbag[i];
            if (item.ItemName == iteminbag.item.ItemName)
            {
                iteminbag.num += num;

                if (iteminbag.num == 0)
                {
                    costumesinbag.Remove(iteminbag);
                    itemnum--;
                    break;
                }

            }
        }
    }

    public void savebag(Save save)
    {
        save.mymoney = mymoney;
        foreach(var item in weaponsinbag)
        {
            save.addweapon(item.item.ItemName,item.num);
        }
        foreach(var item in consumablesinbag)
        {
            save.addconsumable(item.item.ItemName, item.num);
        }
        foreach(var item in propertiesinbag)
        {
            save.addproperty(item.item.ItemName, item.num);
        }
        foreach (var item in costumesinbag)
        {
            save.addcostume(item.item.ItemName, item.num);
        }
    }

    public void loadbag(Save save)
    {
        mymoney = save.mymoney;
        foreach (var iteminsave in save.weaponsinbag)
        {
            Item thisitem=BagManager.instance.finditem(iteminsave.itemname);
            createitem(thisitem, iteminsave.num);
        }
        foreach (var iteminsave in save.consumablesinbag)
        {
            Item thisitem = BagManager.instance.finditem(iteminsave.itemname);
            createitem(thisitem, iteminsave.num);
        }
        foreach (var iteminsave in save.propertiesinbag)
        {
            Item thisitem = BagManager.instance.finditem(iteminsave.itemname);
            createitem(thisitem, iteminsave.num);
        }
        foreach (var iteminsave in save.costumesinbag)
        {
            Item thisitem = BagManager.instance.finditem(iteminsave.itemname);
            createitem(thisitem, iteminsave.num);
        }
    }

}
