using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "Inventory/New NPC")]
public class NPC : ScriptableObject
{
    public GameObject npcprefab;
    public GameObject parent;
    public Transform position;
}
