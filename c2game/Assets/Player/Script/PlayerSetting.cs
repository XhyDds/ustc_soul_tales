using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�����Ŵ浵�仯������
public class PlayerSetting : MonoBehaviour
{
    //����
    [SerializeField]
    private Toggle Toggle;
    [SerializeField]
    private AudioSource myaudio;

    public void Awake()
    {
        if(!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            //�����仯(none)
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
