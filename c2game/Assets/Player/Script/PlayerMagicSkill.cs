using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSkill : MonoBehaviour
{
    public static bool attack;
    Animator anim;

    public GameObject tornado;
    public GameObject hurricane;
    public GameObject fairyBless;
    public GameObject bigThunder;

    private Skill thisskill;
    private int skillMode;
    PlayerAttack playerattackscript=new PlayerAttack();
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.thismode == Player.mode.staffmode)
        {
            if (Input.GetButtonDown("skill1") && !attack)
            {
                thisskill = Player.instance.useskill(0);
                if (thisskill == null)
                    return;
                PlayerMovement.canMove = false;
                skillMode = 0;
                attack = true;
                anim.SetTrigger("magicskill");
            }
            if (Input.GetButtonDown("skill2") && !attack)
            {
                thisskill = Player.instance.useskill(1);
                if (thisskill == null)
                    return;
                PlayerMovement.canMove = false;
                skillMode = 1;
                attack = true;
                anim.SetTrigger("magicskill");
            }
            if (Input.GetButtonDown("skill3") && !attack)
            {
                thisskill = Player.instance.useskill(2);
                if (thisskill == null)
                    return;
                PlayerMovement.canMove = false;
                skillMode = 2;
                attack = true;
                anim.SetTrigger("magicskill");
            }
            if (Input.GetButtonDown("skill4") && !attack)
            {
                thisskill = Player.instance.useskill(3);
                if (thisskill == null)
                    return;
                PlayerMovement.canMove = false;
                skillMode = 3;
                attack = true;
                anim.SetTrigger("magicskill");
            }
        }
    }

    public void magicAttack()
    {
        if (skillMode == 0)
        {
            Hurricane();
        }
        else if (skillMode == 1)
        {
            Tornado();
        }
        else if (skillMode == 2)
        {
            FairyBless();
        }
        else if (skillMode == 3)
        {
            BigThunder();
        }
    }

    void Tornado()
    {
        Instantiate(tornado, transform.position + new Vector3(0, 2, 0), tornado.transform.rotation);
    }

    void Hurricane()
    {
        Instantiate(hurricane, transform.position + new Vector3(0, 2, 0), transform.rotation);
    }

    void FairyBless()
    {
        Instantiate(fairyBless, transform.position + new Vector3(0, 2, 0), transform.rotation);
    }

    void BigThunder()
    {
        GameObject nearest = playerattackscript.findNearest(transform);
        if (nearest != null)
            Instantiate(bigThunder, nearest.transform.position, bigThunder.transform.rotation);
    }

    public void endMagicAttack()
    {
        attack = false;
        PlayerMovement.canMove = true;
    }
}
