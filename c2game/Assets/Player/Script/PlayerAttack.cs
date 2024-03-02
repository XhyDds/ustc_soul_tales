using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    static public bool attack;
    private PolygonCollider2D polycoli;
    Transform enemyTrans;
    public GameObject thunder;
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        polycoli = gameObject.GetComponentInChildren<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.instance.thismode==Player.mode.staffmode)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                attack = true;
                anim.SetTrigger("magicAttack");
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("isAttack", true);
                attack = true;
                PlayerMovement.canMove = false;
                anim.SetTrigger("swordAttack");
            }
        }
    }

    public void enableHitbox()
    {
        attack = true;
        polycoli.enabled = true;
    }

    public void disableHitbox()
    {
        attack = false;
        polycoli.enabled = false;
        PlayerMovement.canMove = true;
        anim.SetBool("isAttack", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            int damage = 1 * (Player.instance.strength - other.gameObject.GetComponent<EnemyGeneral>().defence);
            other.GetComponent<EnemyGeneral>().TakeDamage(damage);
            enemyTrans = other.GetComponent<Transform>();
        }
    }
    public void endAttack()
    {
        attack = false;
        PlayerMovement.canMove = true;
        PlayerSwordSkill.attack = false;
        PlayerMagicSkill.attack = false;
        PlayerSwordSkill.startRush = false;
        anim.SetBool("isAttack", false);
    }

    public void Thunder()
    {
        if (enemyTrans != null)
            Instantiate(thunder, enemyTrans.position, thunder.transform.rotation);
    }

    public GameObject findNearest(Transform playerTrans)
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        
        for (int i = 0; i < enemy.Length; i++) 
        {
            if ((enemy[i].transform.position.x - playerTrans.transform.position.x)*(playerTrans.transform.eulerAngles.y > 100f ? -1 : 1) > 0 && (nearest == null||(enemy[i].transform.position - playerTrans.position).sqrMagnitude < (nearest.transform.position - playerTrans.position).sqrMagnitude) ) 
            {
                nearest = enemy[i];
            }
        }
        return nearest;
    }
}
