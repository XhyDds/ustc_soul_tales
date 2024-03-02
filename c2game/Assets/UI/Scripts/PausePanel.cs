using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public Button exitbtn;

    public GameObject loadingscene;

    private void Start()
    {
        exitbtn.onClick.AddListener(delegate { exitevent(); });
    }


    public void exitevent()
    {
        loadingscene.SetActive(true);
        loadingscene.GetComponent<Loading>().loadassignedscene(0);
    }

}
