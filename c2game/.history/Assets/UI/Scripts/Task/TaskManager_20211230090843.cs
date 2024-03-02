using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;

    public struct ingtask
    {
        public Task thistask;
        public bool isfinished;
    }

    public List<ingtask> tasks_ing = new List<ingtask>();
    public List<Task> tasks_unstart = new List<Task>();
    public List<Task> tasks_ended = new List<Task>();


    private void Awake()
    {
        if(instance!=null)
        {
            GameObject.Destroy(instance);
        }
        instance = this;
        if(MainMenu.isnewgame==true)
        {
            addtaskintoing(0,true);
        }
    }

    public void finishtask(Task task)
    {
        //reward
        BagManager.instance.editmoney(task.reward_money);
        Player.instance.getexp(task.reward_exp);
        foreach (Item thisitem in task.reward_item)
        {
            BagManager.instance.edititem(thisitem);
        }
        //处理该任务
        removetaskfroming(task);
        //开启下一个任务
        addtaskintoing(task.nextindex);
        //开启支线
        foreach (Task branchline in task.branchlines)
        {
            addtaskintoing(branchline.taskindex);
        }
        //npcs
        foreach (NPC thisnpc in task.npcs_enable)
        {
            GameObject thisnpcprefab = thisnpc.npcprefab;

            GameObject thisnpcobj = Instantiate<GameObject>(thisnpcprefab, thisnpc.parent.transform, thisnpc.position);
        }
        foreach (NPC thisnpc in task.npcs_dissable)
        {
            GameObject thisnpcobj;
            foreach (GameObject thisobj in GameObject.FindGameObjectsWithTag("NPC"))
            {
                if (thisobj.GetComponent<NPCinfo>().thisnpc.name == thisnpc.name)
                {
                    thisnpcobj = thisobj;
                    GameObject.Destroy(thisnpcobj);
                    break;
                }
            }
        }
        //scenes
        //organs

    }

    public void addtaskintoing(int taskindex,bool iffinished=false)
    {
        if (taskindex != -1)
        {
            bool hasfound = false; ;
            Task thistask=null;
            foreach(Task taskselected in tasks_unstart)
            {
                if(taskselected.taskindex==taskindex)
                {
                    thistask = taskselected;
                    hasfound = true;
                    break;
                }
            }
            if (!hasfound)
                return;
            ingtask taskadded = new ingtask();
            taskadded.thistask = thistask;
            taskadded.isfinished = iffinished;

            tasks_ing.Add(taskadded);
            tasks_unstart.Remove(thistask);
        }
    }
    public void removetaskfroming(Task task)
    {
        tasks_ended.Add(task);
        foreach (var ingtask in tasks_ing)
        {
            if (ingtask.thistask == task)
            {
                tasks_ing.Remove(ingtask);//是因为立即返回而无bug吗
                break;
            }
        }
    }

    //存档
    public void savetask(Save save)
    {
        foreach(ingtask thistask in tasks_ing)
        {
            save.addingtask(thistask.thistask.taskindex, thistask.isfinished);
        }
        /*foreach(Task thistask in tasks_unstart)       //无需存储
        {
            save.tasks_unstart.Add(thistask.taskname);
        }*/
        foreach (Task thistask in tasks_ended)
        {
            save.tasks_ended.Add(thistask.taskindex);
        }
    }
    public void loadtask(Save save)
    {
        foreach(var ingtaskinsave in save.tasks_ing)
        {
            addtaskintoing(ingtaskinsave.thistaskindex, ingtaskinsave.isfinished);
        }
        foreach(int taskinsave in save.tasks_ended)
        {
            loadtaskintoended(taskinsave);
        }
    }
    public void loadtaskintoended(int taskindex)
    {
        if (taskindex != -1)
        {
            Task thistask = null;
            foreach (Task taskselected in tasks_unstart)
            {
                if (taskselected.taskindex == taskindex)
                {
                    thistask = taskselected;
                    break;
                }
            }

            tasks_ended.Add(thistask);
            tasks_unstart.Remove(thistask);
        }
    }

    public ingtask findingtaskbyindex(int taskindex)
    {
        ingtask targettask;

        ingtask nulltask = new ingtask();
        nulltask.thistask = null;
        nulltask.isfinished = false;

        targettask = nulltask;
        foreach(ingtask thistask in tasks_ing)
        {
            if(thistask.thistask.taskindex==taskindex)
            {
                targettask = thistask;
            }
        }

        return targettask;
    }

    //事件切换(以后再改进)
    private bool task1_1;
    private bool task1_2;

    public void task1change(int i)
    {
        switch(i)
        {
            case 1:
                task1_1 = true;
                break;
            case 2:
                task1_2 = true;
                break;
        }
        if(task1_1&&task1_2)
        {
            ingtask thistask=findingtaskbyindex(1);
            thistask.isfinished = true;
        }
    }
    
}
