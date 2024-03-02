using System.IO;
using UnityEngine;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{
    public Button newgamebtn, continuebtn, settingbtn, exitbtn;
    public GameObject settingobj;//找关闭按钮

    public static bool isnewgame;//在taskmanager与player中使用，在player中置为false;
    public static bool ismenu;

    private void Start()
    {
        ismenu = true;

        newgamebtn.onClick.AddListener(delegate { newgameevent(); });
        continuebtn.onClick.AddListener(delegate { continueevent(); });
        settingbtn.onClick.AddListener(delegate { settingevent(); });
        exitbtn.onClick.AddListener(delegate { exitevent(); });

        settingobj.GetComponentInChildren<Button>().onClick.AddListener(delegate { closesetting(); });

        Sound.instance.audiosource.volume = SettingPanel.volume;
    }

    public void newgameevent()
    {
        isnewgame = true;
        this.transform.Find("LoadingScene").gameObject.SetActive(true);
        this.transform.Find("LoadingScene").GetComponent<Loading>().loadassignedscene(1);
    }

    public void continueevent()
    {
        if (!File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            newgameevent();
            return;
        }
        this.transform.Find("LoadingScene").gameObject.SetActive(true);
        this.transform.Find("LoadingScene").GetComponent<Loading>().loadassignedscene(2);
    }

    public void settingevent()
    {
        settingobj.SetActive(true);
    }

    public void exitevent()
    {
        Application.Quit(0);
    }

    //
    public void closesetting()
    {
        settingobj.SetActive(false);
    }

}