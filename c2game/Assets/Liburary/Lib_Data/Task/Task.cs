using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "Inventory/New Task")]
public class Task : ScriptableObject
{
    [Header("基本信息")]
    public int taskindex;
    public string taskname;

    //主线顺序
    public int lastindex;
    public string lastname;
    public int nextindex;
    public string nextname;

    //开启支线
    public List<Task> branchlines = new List<Task>();

    public List<Item> reward_item = new List<Item>();
    public int reward_money;
    public int reward_exp;

    [TextArea]
    public string taskinfo_unfinished;
    [TextArea]
    public string taskinfo_finished;

    [Header("任务事件")]
    //特殊对话（在npc中按任务编号设置）
    //特殊人物
    public List<NPC> npcs_constant = new List<NPC>();
    public List<NPC> npcs_enable = new List<NPC>();
    public List<NPC> npcs_dissable = new List<NPC>();

    //场景
    public List<Scene> scenes_enable = new List<Scene>();
    public List<Scene> scenes_disable = new List<Scene>();

    //机关（organ）
    public List<Organ> organs = new List<Organ>(); 

}
