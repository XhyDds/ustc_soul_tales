using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Costume", menuName = "Inventory/New Costume")]
public class Costume : ScriptableObject
{
    //����չʾ����Ϣ
    //��Ʒ����
    public string CostumeName;

    [TextArea]
    public string CostumeInfo;

}