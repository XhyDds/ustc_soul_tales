using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordSkill : MonoBehaviour
{
    PolygonCollider2D polycoli; 
    Animator anim;
    Rigidbody2D rb2D;
    PlayerAttack playerAttackscript = new PlayerAttack();

    public static bool attack = false;
    private Skill thisskill;

    public static bool startRush = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        polycoli = gameObject.GetComponentInChildren<PolygonCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()           //û�м����ܻ�����
    {
        if (Player.instance.thismode == Player.mode.swordmode)
        {
            if (Input.GetButtonDown("skill1") && !attack)
            {
                thisskill=Player.instance.useskill(0);
                if (thisskill == null)
                    return;
                PlayerMovement.canMove = false;
                attack = true;
                anim.SetTrigger("swordskill1");
            }
            if (Input.GetButtonDown("skill2") && !attack)
            {
                thisskill=Player.instance.useskill(1);
                if (thisskill == null)
                    return;
                PlayerMovement.canMove = false;
                attack = true;
                anim.SetTrigger("swordskill2");
            }
            if (Input.GetButtonDown("skill3") && !attack)
            {
                thisskill=Player.instance.useskill(2);
                if (thisskill == null)
                    return;
                PlayerMovement.canMove = false;
                attack = true;
                anim.SetTrigger("swordskill3");
            }
            if (Input.GetButtonDown("skill4") && !attack)
            {
                thisskill=Player.instance.useskill(3);
                if (thisskill == null)
                    return;
                PlayerMovement.canMove = false;
                attack = true;
                anim.SetTrigger("swordskill4");
            }
        }
        if (thisskill == null)
            return;
        if (thisskill.SkillName=="电光火石" && startRush)
        {
            Vector3 movement = new Vector3(transform.eulerAngles.y > 100f ? -1 : 1, 0, 0);
            rb2D.transform.position += movement * 10 * Time.deltaTime;
        }
    }

    public void startSwordSkill()
    {
        polycoli.enabled = true;
    }
    public void endSwordSkill()
    {
        attack = false;
        polycoli.enabled = false;
        PlayerMovement.canMove = true;
    }

    public void Rush()
    {
        startRush = true;
    }
    public void endRush()
    {
        startRush = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")&&attack==true)
        {
            int damage = (int)(thisskill.multiple/100f * (Player.instance.strength - other.GetComponent<EnemyGeneral>().defence));
            other.GetComponent<EnemyGeneral>().TakeDamage(damage);
            if (thisskill.SkillName=="����˹����")
            {
                other.GetComponent<EnemyGeneral>().����(transform.position.x - other.GetComponent<Transform>().position.x, 1);
            }
        }
    }

    public void finalAttack()
    {
        GameObject nearest = playerAttackscript.findNearest(this.transform);
        if (nearest != null)
            transform.position = nearest.transform.position + new Vector3(transform.eulerAngles.y > 100f ? 2 : -2, 0, 0);
    }
}
