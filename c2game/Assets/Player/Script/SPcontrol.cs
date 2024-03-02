using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPcontrol : MonoBehaviour
{
    //NormalHit

    //SwordSkill
    public GameObject flash1;
    public GameObject flash2;
    public GameObject rushflash;
    public GameObject roundflash;
    public GameObject firehit;
    public GameObject waterhit;
    public GameObject crosshit;
    public GameObject holysword;

    //StaffSkill
    public GameObject chantingflash;
    public GameObject chantingcircle;

    public void flash1enable()
    {
        flash1.SetActive(true);
    }
    public void flash1dissable()
    {
        flash1.SetActive(false);
    }

    public void flash2enable()
    {
        flash2.SetActive(true);
    }
    public void flash2dissable()
    {
        flash2.SetActive(false);
    }

    public void rushflashenable()
    {
        rushflash.SetActive(true);
    }
    public void rushflashdissable()
    {
        rushflash.SetActive(false);
    }

    public void roundflashenable()
    {
        roundflash.SetActive(true);
    }
    public void roundflashdissable()
    {
        roundflash.SetActive(false);
    }
    //
    public void firehitenable()
    {
        firehit.SetActive(true);
    }
    public void firehitdissable()
    {
        firehit.SetActive(false);
    }

    public void waterhitenable()
    {
        waterhit.SetActive(true);
    }
    public void waterhitdissable()
    {
        waterhit.SetActive(false);
    }

    public void crosshitenable()
    {
        crosshit.SetActive(true);
    }
    public void crosshitdissable()
    {
        crosshit.SetActive(false);
    }
    //
    public void chantingflashenable()
    {
        chantingflash.SetActive(true);
    }
    public void chantingflashdissable()
    {
        chantingflash.SetActive(false);
    }
    public void chantingcircleenable()
    {
        chantingcircle.SetActive(true);
    }
    public void chantingcircledissable()
    {
        chantingcircle.SetActive(false);
    }
}
