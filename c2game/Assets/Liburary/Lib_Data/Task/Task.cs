using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "Inventory/New Task")]
public class Task : ScriptableObject
{
    [Header("������Ϣ")]
    public int taskindex;
    public string taskname;

    //����˳��
    public int lastindex;
    public string lastname;
    public int nextindex;
    public string nextname;

    //����֧��
    public List<Task> branchlines = new List<Task>();

    public List<Item> reward_item = new List<Item>();
    public int reward_money;
    public int reward_exp;

    [TextArea]
    public string taskinfo_unfinished;
    [TextArea]
    public string taskinfo_finished;

    [Header("�����¼�")]
    //����Ի�����npc�а����������ã�
    //��������
    public List<NPC> npcs_constant = new List<NPC>();
    public List<NPC> npcs_enable = new List<NPC>();
    public List<NPC> npcs_dissable = new List<NPC>();

    //����
    public List<Scene> scenes_enable = new List<Scene>();
    public List<Scene> scenes_disable = new List<Scene>();

    //���أ�organ��
    public List<Organ> organs = new List<Organ>(); 

}
