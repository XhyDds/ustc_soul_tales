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

    [Header("ʱ����Ʋ���")]
    public float activetime;//��ʾ����ʱ��
    public float activestart;//��ÿ�ʼ��ʾʱ��

    [Header("��͸���ȵ��ڲ���")]
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
