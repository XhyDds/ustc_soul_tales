using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    static public float volume=1;
    //Music
    public Slider musicslider;
    private void Start()
    {
        InitVolume();
    }

    private void Update()
    {
        volume= musicslider.value;
        Sound.instance.audiosource.volume = volume;
    }

    public void InitVolume()
    {
        Sound.instance.audiosource.volume=musicslider.value = volume;
    }
}
