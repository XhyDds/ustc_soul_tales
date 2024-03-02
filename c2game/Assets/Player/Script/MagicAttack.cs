using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    static public Vector3 startPos;
    private GameObject weapon;
    private GameObject player;
    public GameObject cjbprefab;
    // Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.Find("weapon");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void staffattack()
    {
        PlayerAttack.attack = true;
        startPos = weapon.transform.position;
        Instantiate(cjbprefab, weapon.transform.position, player.transform.rotation);
    }
    


}
