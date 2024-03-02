using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�޹�������Ŀǰֻ֧��8��

public class TaskPanel : MonoBehaviour
{
    public static TaskPanel instance;

    public GameObject tasksparent;
    public GameObject taskprefab;
    public GameObject thistaskobj;

    public Button finishbtn;
    public Text tasktitle;
    public Text taskinfo;
    public Text taskisfinished;

    public GameObject rewardpanel;
    public static bool rewarding;

    public GameObject rewardbar;
    public GameObject moneyreward;
    public GameObject expreward;
    public GameObject rewardprefab;

    private List<GameObject>  rewardslots=new List<GameObject>();

    private void Awake()
    {
        if (instance != null)
            GameObject.Destroy(instance);
        instance = this;
    }
    private void Start()
    {
        finishbtn.onClick.AddListener(delegate { finishtask(); });


        rewardslots.Add(moneyreward);
        rewardslots.Add(expreward);
    }

        
    private void OnEnable()
    {
        cleartask();
        StartCoroutine(waitforload());
    }
    IEnumerator waitforload()
    {
        yield return TaskManager.instance;
        inittask();
    }
    public void inittask()
    {
        showtaskinfo(null);
        bool isfirst=true;
        foreach(var ingtask in TaskManager.instance.tasks_ing)          //��ingtask��ֵ���������
        {
            Task task= ingtask.thistask;
            GameObject taskobj = Instantiate<GameObject>(taskprefab,tasksparent.transform);
            taskobj.GetComponent<TaskInfo_play>().thistask = task;
            taskobj.GetComponent<TaskInfo_play>().isfinished = ingtask.isfinished;
            taskobj.GetComponentInChildren<Text>().text = task.name;
            taskobj.GetComponent<Button>().onClick.AddListener(delegate { showtaskinfo(taskobj.GetComponent<TaskInfo_play>().thistask, taskobj.GetComponent<TaskInfo_play>().isfinished); });

            if (ingtask.isfinished)
                taskisfinished.text = "Finished.";
            else
                taskisfinished.text = "Unfinished";

            if(isfirst)
            {
                thistaskobj = taskobj;
                isfirst = false;
                showtaskinfo(task,thistaskobj.GetComponent<TaskInfo_play>().isfinished);
            }
        }
    }
    public void cleartask()
    {
        foreach(GameObject tasks in GameObject.FindGameObjectsWithTag("Task"))
        {
            GameObject.Destroy(tasks);
        }
        showtaskinfo(null);
    }
    public void finishtask()
    {
        if (thistaskobj == null)
            return;
        if(thistaskobj.GetComponent<TaskInfo_play>().isfinished)
        {
            rewardpanel.SetActive(true);
            rewarding = true;

            Task thistask = thistaskobj.GetComponent<TaskInfo_play>().thistask;
            moneyreward.GetComponentInChildren<Text>().text = thistask.reward_money + "";
            expreward.GetComponentInChildren<Text>().text = thistask.reward_exp + "";
            foreach (Item item in thistask.reward_item)
            {
                GameObject thisobj=Instantiate<GameObject>(rewardprefab, rewardbar.transform);
                thisobj.GetComponent<Image>().sprite = item.ItemImage;
                thisobj.GetComponentInChildren<Text>().text = 1+"";//(����������ʾ)
                rewardslots.Add(thisobj);
            } 
            
        }
    }
    public void showtaskinfo(Task task,bool isfinished=false)
    {
        if(task==null)
        {
            tasktitle.text = "";
            taskinfo.text = "";
        }
        else
        {
            tasktitle.text = task.taskname;
            if (isfinished)
                taskinfo.text = task.taskinfo_finished;
            else
                taskinfo.text = task.taskinfo_unfinished;
        }
    }
    public void okevent()
    {
        for(int i=2;i<rewardslots.Count;i++)
        {
            GameObject.Destroy(rewardslots[i]);
        }

        Task thistask = thistaskobj.GetComponent<TaskInfo_play>().thistask;
        TaskManager.instance.finishtask(thistask);

        rewardpanel.SetActive(false);
        rewarding = false;

        cleartask();
        inittask();
    }
}
