using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneral : MonoBehaviour
{
    protected bool isBoss;

    public int strength;
    public int defence;
    public int hp;
    public int hp_m;

    public float flashTime = 0.25f;
    public float time = 0.15f;
    protected Animator anim;
    public SpriteRenderer Sr;
    private Color originalColor;
    protected Rigidbody2D rb2D;

    public Enemy thisenemy;

    public Sprite bossimage;
    public GameObject bararea;
    public GameObject barprefab;//ǰ��������boss
    private GameObject enemybar;
    public GameObject magiccircle;

    // Start is called before the first frame update
    protected void Start()
    {
        anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        originalColor = Sr.color;

        isBoss = thisenemy.isboss;
        strength = thisenemy.strength;
        defence = thisenemy.defence;
        hp = hp_m = thisenemy.health;

        if (isBoss == true)
        {
            enemybar = Instantiate<GameObject>(barprefab, bararea.transform);
            enemybar.GetComponent<EnemyInfoForBar>().obj = this.gameObject;
            enemybar.GetComponent<EnemyInfoForBar>().updatehp();
            enemybar.GetComponent<EnemyInfoForBar>().bossname.text = thisenemy.enemyname;
            enemybar.GetComponent<EnemyInfoForBar>().bossimage.sprite = bossimage;
        }
        else
        {
            /*enemybar.SetActive(true);
            enemybar.GetComponent<EnemyInfoForBar>().obj = this.gameObject;
            enemybar.GetComponent<EnemyInfoForBar>().updatehp();*/
        }
    }

    protected void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp > 0)
        {
            anim.SetTrigger("GotHit");
            FlashColor(flashTime);
        }
        else
        {
            hp = 0;
        }
        if(isBoss)//�ݻ�֮��
            enemybar.GetComponent<EnemyInfoForBar>().updatehp();
        if(hp==0)
        {
            StartCoroutine(Destr());
        }

    }

    IEnumerator Destr()
    {
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(time);

        Player.instance.getexp(thisenemy.rewardexp);
        MyBag.instance.mymoney += thisenemy.rewardmoney;
        deathevent();

        if (isBoss)
            GameObject.Destroy(enemybar);
        /*else
            enemybar.SetActive(false);*/
        Destroy(gameObject);
    }

    public void deathevent()
    {
        if(thisenemy.enemyindex==1)
        {
            Boss1.islive = false;
            TaskManager.instance.taskchange(1);
            magiccircle.GetComponent<MagicCircle>().stimulate();
        }
        if(thisenemy.enemyindex==2)
        {
            Boss2.islive = false;
            TaskManager.instance.taskchange(2);
            magiccircle.GetComponent<MagicCircle>().stimulate();
        }
            
    }

    void FlashColor(float time)
    {
        Sr.color = Color.red;
        Invoke("ResetColor", time);
    }
    void ResetColor()
    {
        Sr.color = originalColor;
    }

    public void ����(float ����,int ����)
    {
        if(!isBoss)
        {
            if (���� > 0)
                rb2D.transform.eulerAngles = new Vector3(0, 0, 0);
            else
                rb2D.transform.eulerAngles = new Vector3(0, 180, 0);
            Vector3 forceDirection = new Vector3(���� > 0 ? -���� : ����, ����, 0);
            rb2D.AddForce(forceDirection, ForceMode2D.Impulse);
        }
    }
}
