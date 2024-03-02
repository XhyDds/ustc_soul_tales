using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rewardget : MonoBehaviour
{
    public Button getbtn;

    private void OnEnable()
    {
        getbtn.onClick.AddListener(delegate{ TaskPanel.instance.okevent(); });
    }
}
