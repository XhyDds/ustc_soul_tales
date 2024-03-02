using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Intereactive : MonoBehaviour
{
    public List<Item> RequireItem=new List<Item>();

    public int dialogue_num=0;
    public List<bool> is_done=new List<bool>();

    public void CheckItem(Item thisitem)
    {
      int i=0;
      foreach (var item in RequireItem)
      {
        if(thisitem==item&&!(is_done[i]))
        {
          is_done[i]=true;
          i++;
        }
      }
    }


}
