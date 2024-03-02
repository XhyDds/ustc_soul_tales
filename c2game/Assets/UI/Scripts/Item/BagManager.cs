using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//暂时限制个数，且无discard（）
//可外调函数：editbag();editmoney();

public class BagManager : MonoBehaviour
{
    public static BagManager instance;

    private GameObject player;
    private GameObject bag;
    public GameObject grid;
    public GameObject slotprefab;
    public Text title_info, info_speci, data;
    private GameObject thisslot;
    public List<GameObject> bagslots = new List<GameObject>();
    public Text moneybox;

    public Button usebtn;

    private int slotnum = 0;
    private int slotmaxnum = 18;

    public List<Item> itemlib = new List<Item>();


    private void Awake()
    {

        if(instance!=null)
        {
            GameObject.Destroy(instance);
            instance = this;
        }
        instance = this;

        player = GameObject.FindWithTag("Player");
        bag = player.transform.Find("MyBag").gameObject;


        usebtn.onClick.AddListener(delegate { useitem(); });
    }

    private void OnEnable()
    {
        inititems();

        if (bagslots.Count != 0)
            thisslot = bagslots[0];
        else
            thisslot = null;

        showiteminfo(thisslot);
    }

    //初始化

    private void inititems()
    {
        clearslots();

        foreach(var item in bag.GetComponent<MyBag>().weaponsinbag)
        {
            createitem_L(item.item, item.num);
        }
        foreach (var item in bag.GetComponent<MyBag>().consumablesinbag)
        {
            createitem_L(item.item, item.num);
        }
        foreach (var item in bag.GetComponent<MyBag>().propertiesinbag)
        {
            createitem_L(item.item, item.num);
        }
        foreach (var item in bag.GetComponent<MyBag>().costumesinbag)
        {
            createitem_L(item.item, item.num);
        }
    }

    //更新物品
    private int createitem_L(Item item,int num=1)       //无修改MyBag
    {
        if (num <= 0)
            return num-1;       //使用不存在的物品
        if (slotnum == slotmaxnum)       //背包已满
            return -1;
        GameObject slot = Instantiate(instance.slotprefab, instance.grid.transform.position, Quaternion.identity);

        slot.transform.SetParent(instance.grid.transform);
        slot.name = item.ItemName+"slot";

        slot.GetComponent<BagSlot>().item = item;
        slot.GetComponent<BagSlot>().itemimage.sprite = item.ItemImage;
        slot.GetComponent<BagSlot>().itemnum = num;
        slot.GetComponent<BagSlot>().itemnumtext.text = num + "";

        bagslots.Add(slot);

        Button btn = slot.GetComponent<Button>();
        btn.onClick.AddListener(delegate { showiteminfo(slot); });


        return num;
    }

    private int createitem(Item item, int num = 1)
    {
        bag.GetComponent<MyBag>().createitem(item, num);
        return createitem_L(item, num);

    }

    //更新money
    public int editmoney(int num)
    {
        int money = bag.GetComponent<MyBag>().mymoney;

        if (money + num < 0)
            return money + num;

        money += num;
        bag.GetComponent<MyBag>().mymoney = money;

        moneybox.text = money + "";

        return money;
    }

    public int edititem(Item item,int num=1)           //负数代表消耗失败或者背包已满
    {
        foreach(GameObject slot in bagslots)
        {
            if(item.ItemName==slot.name)
            {
                int itemnum = slot.GetComponent<BagSlot>().itemnum;
                if (itemnum + num < 0)      //使用失败
                    return itemnum + num;

                int numnow=itemnum+=num;
                slot.GetComponent<BagSlot>().itemnumtext.text = num + "";

                if(itemnum==0)
                {
                    bagslots.Remove(slot);
                    GameObject.Destroy(slot);
                    slotnum--;

                    bag.GetComponent<MyBag>().edititem(item, num);

                    return 0;
                }

                bag.GetComponent<MyBag>().edititem(item, num);
                return numnow;
            }
        }

        return createitem(item, num);
    }

    //button事件
    public void showiteminfo(GameObject slot)
    {
        if(slot==null)
        {
            title_info.text = info_speci.text = data.text = "";
            return;
        }
        Item item = slot.GetComponent<BagSlot>().item;
        title_info.text = item.ItemName;
        info_speci.text = item.ItemInfo;
        data.text = item.datamode+item.data;

        thisslot = slot;
    }

    public void useitem()
    {
        if(thisslot!=null)
        {
            Item thisitem = thisslot.GetComponent<BagSlot>().item;
            switch (thisitem.thismode)
            {
                case Item.mode.sword: case Item.mode.staff:
                    player.GetComponent<Player>().changeweapon(thisitem);
                    break;
                case Item.mode.consumable:
                    edititem(thisitem, -1);
                    //效果
                    break;
                case Item.mode.property:
                    //暂不实现
                    break;
                case Item.mode.costume:
                    player.GetComponent<Player>().changecostume(thisitem.costume);
                    break;
                    
            }
        }
    }

    public void clearslots()
    {
        for(int i=bagslots.Count-1;i>=0;i--)
        {
            GameObject thisslot = bagslots[i];
            GameObject.Destroy(thisslot);
            bagslots.Remove(thisslot);
        }
    }

    public Item finditem(string itemname)
    {
        Item aimeditem=null;

        foreach(Item thisitem in itemlib)
        {
            if(thisitem.ItemName==itemname)
            {
                aimeditem = thisitem;
                break;
            }
        }
        return aimeditem;
    }
}