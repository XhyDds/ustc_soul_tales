using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public string objtag;
    private Transform obj;

    private SpriteRenderer thissprite;
    private SpriteRenderer objsprite;

    private Color color;

    [Header("时间控制参数")]
    public float activetime;//显示持续时间
    public float activestart;//获得开始显示时间

    [Header("不透明度调节参数")]
    private float alpha;
    public float rset;
    public float gset;
    public float bset;
    public float alphaset;
    public float alphamultiplier;

    private void OnEnable()
    {
        obj = GameObject.FindGameObjectWithTag(objtag).transform;
        thissprite = GetComponent<SpriteRenderer>();
        objsprite = obj.GetComponent<SpriteRenderer>();

        alpha = alphaset;

        thissprite.sprite = objsprite.sprite;

        transform.position = obj.position;
        transform.rotation = obj.rotation;
        transform.localScale = obj.localScale;

        activestart = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        alpha *= alphamultiplier;
        color = new Color(rset,gset,bset,alpha);
        thissprite.color = color;

        if(Time.time>=activestart+activetime)
        {
            ShadowPool.instance.returnpool(this.gameObject);
        }
    }
}
