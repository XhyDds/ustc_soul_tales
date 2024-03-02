using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//不跟着存档变化的设置
public class PlayerSetting : MonoBehaviour
{
    //声音
    [SerializeField]
    private Toggle Toggle;
    [SerializeField]
    private AudioSource myaudio;

    public void Awake()
    {
        if(!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            //按键变化(none)
            myaudio.enabled = true;
            PlayerPrefs.Save();
        }
        else
        {
            if(PlayerPrefs.GetInt("music")==0)
            {
                //
                myaudio.enabled = false;
            }
            else
            {
                //
                myaudio.enabled = true;
            }
        }
    }
}
