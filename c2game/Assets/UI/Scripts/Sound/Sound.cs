using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance;
    public AudioSource audiosource;

    public int index;

    public List<AudioClip> backgroundMusics;

    private void Awake()
    {
        if(instance!=null)
        {
            GameObject.Destroy(instance);
        }
        instance = this;
    }

    private void Start()
    {
        playbackgroundmusic(index,true);
    }
    public void playbyname(string name, bool isloop = false)
    {
        AudioClip thisaudio = Resources.Load<AudioClip>(Application.persistentDataPath + "/Music/" + name);
        audiosource.loop = isloop;
        audiosource.Play();
    }
    public void playbackgroundmusic(int index,bool isloop=false)
    {
        audiosource.clip = backgroundMusics[index];
        audiosource.loop = isloop;
        audiosource.Play();
    }
}
