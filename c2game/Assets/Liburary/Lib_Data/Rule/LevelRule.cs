using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelRule", menuName = "Inventory/New LevelRule")]
public class LevelRule : ScriptableObject
{
    //µÈ²î
    enum addtype { health,mana,strength,defence};
    public List<int> delta = new List<int>();
    public List<int> init_d = new List<int>();
    //µÈ±È
    enum multtype { exp};
    public List<float> mutiple = new List<float>();
    public List<int> init_m = new List<int>();

}
