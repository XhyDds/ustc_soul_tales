using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveRule", menuName = "Inventory/New MoveRule")]
public class MoveRule : ScriptableObject
{
    public float jumpVelocity;
    public float fallMutiplier;
    public float lowJumpMultiplier;
    public float speed;
}
