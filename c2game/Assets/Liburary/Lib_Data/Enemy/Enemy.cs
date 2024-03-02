using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Inventory/New Enemy")]
public class Enemy : ScriptableObject
{ 
    public int enemyindex;
    public string enemyname;
    public Sprite enemysprite;
    public bool isboss;

    public int health;
    public int strength;
    public int defence;

    public int rewardexp;
    public int rewardmoney;

    [TextArea]
    public string enemyinfo;
}
