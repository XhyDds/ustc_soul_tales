using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSpawn : EnemySpawn
{
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        spawnInterval = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
