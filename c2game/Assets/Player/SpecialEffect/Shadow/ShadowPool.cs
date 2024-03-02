using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;

    public GameObject shadowprefab;

    public int prefabcount;

    private Queue<GameObject> availableobjs = new Queue<GameObject>();

    private void Awake()
    {
        instance = this;
        //初始化pool
        fillpool();
    }

    public void fillpool()
    {
        for(int i=0;i<prefabcount;i++)
        {
            var newshadow = Instantiate(shadowprefab);
            newshadow.transform.SetParent(transform);

            //进入对象池
            returnpool(newshadow);
        }
    }

    public void returnpool(GameObject obj)
    {
        obj.SetActive(false);
        availableobjs.Enqueue(obj);
    }

    public GameObject getfrompool()
    {
        if(availableobjs.Count==0)
        {
            fillpool();
        }
        var outshadow = availableobjs.Dequeue();
        outshadow.SetActive(true);
        return outshadow;
    }
}
