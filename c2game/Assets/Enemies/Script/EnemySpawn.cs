using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public string Tag;
    protected bool canSpawn;
    protected float spawnInterval;
    protected float time;
    protected int maxnum=5;
    protected Object[] left;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
    }

    // Update is called once per frame
    protected void Update()
    {
        left = GameObject.FindGameObjectsWithTag(Tag);
        time -= Time.deltaTime;
        if (time <= 0)
        {
            if (left.Length < maxnum && player.transform.position.x - transform.position.x <= 5 && player.transform.position.x - transform.position.x >= -5)
                spawn(EnemyPrefab);
            time = spawnInterval;
        }
    }

    protected void spawn(GameObject EnemyPrefab)
    {
        Instantiate(EnemyPrefab, transform.position,transform.rotation);
    }
}
