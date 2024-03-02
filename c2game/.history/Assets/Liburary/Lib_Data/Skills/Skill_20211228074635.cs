using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "Inventory/New Skill")]
public class Skill : ScriptableObject
{
    public string SkillName;
    public Sprite SkillImage;
    public enum mode { swordmode, staffmode };
    public KeyCode key;

    public int multiple;
    public int manaconsumed;
    public int cooldown;
    [TextArea]
    public string SkillInfo;
}
