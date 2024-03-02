using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    //物品属性
    public string ItemName;
    public Sprite ItemImage;
    //攻击值法力值蓝条等属性
    public enum mode { sword, staff, consumable, property ,costume};
    public mode thismode;
    public string datamode;
    public int data;

    public Costume costume;//暂时

    [TextArea]
    public string ItemInfo;
}

