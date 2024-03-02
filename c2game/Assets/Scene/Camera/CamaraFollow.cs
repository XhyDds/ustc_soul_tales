using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    public GameObject player;
    public float smoothing=0.1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position!=transform.position)
        {
            Vector3 targetPos = player.transform.position;
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}
