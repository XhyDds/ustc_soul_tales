using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Costume", menuName = "Inventory/New Costume")]
public class Costume : ScriptableObject
{
    //用于展示的信息
    //物品属性
    public string CostumeName;

    [TextArea]
    public string CostumeInfo;

}