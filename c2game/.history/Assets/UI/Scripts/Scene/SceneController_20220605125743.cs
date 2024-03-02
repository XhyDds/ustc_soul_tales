using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
  //只适用于初、末两个场景
    public GameObject textbox1;

    private void Awake()
    {
      textbox1.SetActive(true);
    }

    private void disable()
    {
      loadingscene.SetActive(true);
      loadingscene.GetComponent<Loading>().loadassignedscene(sceneindex);
    }
}
