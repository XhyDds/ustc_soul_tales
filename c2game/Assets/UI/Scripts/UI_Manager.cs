using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UI_Manager : MonoBehaviour
{
    public GameObject Curtain;
    bool ispulled;
    int ui_opennum;
    List<GameObject> uis = new List<GameObject>();
    List<GameObject> icons = new List<GameObject>();
    List<string> names = new List<string>();
    //
    public GameObject FigurePanel;
    public GameObject Bag;
    public GameObject SkillPanel;
    public GameObject taskpanel;
    public GameObject PauseMenu;

    public GameObject savepanel;
    public GameObject optionpanel;
    public GameObject instructionpanel;
    void Awake()
    {
        ui_opennum = 0;
        ispulled = false;
        //含cbtn的obj通用
        uis.Add(FigurePanel);
        uis.Add(Bag);
        uis.Add(SkillPanel);
        uis.Add(taskpanel);
        uis.Add(PauseMenu);

        uis.Add(savepanel);
        uis.Add(optionpanel);
        uis.Add(instructionpanel);

        ui_opennum = 0;
        
    }

    private void Start()
    {
        foreach (GameObject obj in uis)
        {
            obj.SetActive(true);
            GameObject cbtnobj = obj.GetComponent<UI_1>().cbtnobj;
            if (cbtnobj != null)
            {
                Button cbtn = cbtnobj.GetComponent<Button>();
                cbtn.onClick.AddListener(delegate () { this.cbtnonclick(obj); });
            }
            GameObject obtnobj = obj.GetComponent<UI_1>().obtnobj;
            if (obtnobj != null)
            {
                Button obtn = obtnobj.GetComponent<Button>();
                obtn.onClick.AddListener(delegate () { this.obtnonclick(obj); });
            }
            GameObject iconobj = obj.GetComponent<UI_1>().iconobj;
            if (iconobj != null)
            {
                Button icon = iconobj.GetComponent<Button>();
                icon.onClick.AddListener(delegate () { this.icononclick(obj); });
            }
            obj.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        foreach(GameObject obj in uis)
        {
            usekey(obj);
        }
    }

    //按键
    void usekey(GameObject obj)
    {
        if (TaskPanel.rewarding)
            return;
        bool isopen = obj.GetComponent<UI_1>().isopen;
        if (Input.GetKeyUp(obj.GetComponent<UI_1>().key))
        {
            isopen = !isopen;
            obj.SetActive(isopen);
            ui_opennum += (isopen ? 1 : -1);
            obj.GetComponent<UI_1>().isopen = isopen;
            pullcurtain();
        }
    }
    public void pullcurtain()
    {
        if (ui_opennum>0&&!(ispulled))
        {
            ispulled = !ispulled;
            Curtain.SetActive(ispulled);
            Time.timeScale = 0;
        }
        else if(ui_opennum==0&&ispulled)
        {
            ispulled = !ispulled;
            Curtain.SetActive(ispulled);
            Time.timeScale = 1;
        }
    }
    //button通用
    public void cbtnonclick(GameObject obj)
    {
        if (TaskPanel.rewarding)
            return;
        obj.GetComponent<UI_1>().isopen=false;
        obj.SetActive(false);
        ui_opennum--;
        pullcurtain();
    }
    public void obtnonclick(GameObject obj)
    {
        if (TaskPanel.rewarding)
            return;
        obj.GetComponent<UI_1>().isopen = true;
        obj.SetActive(true);
        ui_opennum++;
        pullcurtain();
    }
    public void icononclick(GameObject obj)
    {
        if (TaskPanel.rewarding)
            return;
        bool isopen=obj.GetComponent<UI_1>().isopen;
        isopen = !isopen;
        obj.SetActive(isopen);
        ui_opennum += (isopen ? 1 : -1);
        obj.GetComponent<UI_1>().isopen = isopen;
        pullcurtain();
    }

}
