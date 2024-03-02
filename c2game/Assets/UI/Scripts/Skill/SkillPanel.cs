using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{
    public Button ToSword, ToStaff;
    public List<Button> skillsbtns = new List<Button>();
    public enum mode { swordmode, staffmode };
    public enum index { Y, U, I, O };
    [Header("mode&index")]
    public mode thismode;
    public index thisindex;
    [Header("skills")]
    public List<Skill> skills = new List<Skill>();     //使用hash
    Skill thisskill;
    public Text SkillName;
    public Text SkillInfo;

    private void Awake()
    {
        thismode = mode.swordmode;
        thisindex = index.Y;

        ToSword.onClick.AddListener(delegate () { this.changemode(0); });
        ToStaff.onClick.AddListener(delegate () { this.changemode(1); });

        skillsbtns[0].onClick.AddListener(delegate () { this.changeskill(0); });
        skillsbtns[1].onClick.AddListener(delegate () { this.changeskill(1); });
        skillsbtns[2].onClick.AddListener(delegate () { this.changeskill(2); });
        skillsbtns[3].onClick.AddListener(delegate () { this.changeskill(3); });
    }

    private void OnEnable()
    {
        GameObject player = GameObject.FindWithTag("Player");
        thismode = (mode)player.GetComponent<Player>().thismode;
        init();
    }

    public void init()
    {
        for (int i = 0; i < 4; i++)
        {
            int numhashed = i + 4 * (int)thismode;
            skillsbtns[i].transform.Find("Image").gameObject.GetComponent<Image>().sprite = skills[numhashed].SkillImage;
        }
        changeskill(0);
    }

    public void changemode(int j)
    {
        if ((int)thismode != j)
        {
            thismode = (mode)(1-(int)thismode);

            //changeimages
            for (int i = 0; i < 4; i++)
            {
                int numhashed = i + 4 * (int)thismode;
                skillsbtns[i].transform.Find("Image").gameObject.GetComponent<Image>().sprite = skills[numhashed].SkillImage;
            }

            changeskill(0);
        }
    }

    public void changeskill()
    {
        int numhashed = (int)thisindex + 4 * (int)thismode;
        thisskill = skills[numhashed];
        SkillName.text = thisskill.SkillName;
        SkillInfo.text = thisskill.SkillInfo;
    }
    public void changeskill(int i)
    {
        thisindex = (index)i;
        int numhashed = (int)thisindex + 4 * (int)thismode;
        thisskill = skills[numhashed];
        SkillName.text = thisskill.SkillName;
        SkillInfo.text = thisskill.SkillInfo;
    }

}
