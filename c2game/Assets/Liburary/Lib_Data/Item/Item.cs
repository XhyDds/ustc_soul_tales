using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    //��Ʒ����
    public string ItemName;
    public Sprite ItemImage;
    //����ֵ����ֵ����������
    public enum mode { sword, staff, consumable, property ,costume};
    public mode thismode;
    public string datamode;
    public int data;

    public Costume costume;//��ʱ

    [TextArea]
    public string ItemInfo;
}

