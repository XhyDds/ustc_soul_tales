using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropAndGet : MonoBehaviour
{
    public static ItemDropAndGet instance;

    public GameObject itemprefab;

    private void Awake()
    {
        if(instance!=null)
        {
            GameObject.Destroy(instance);
        }
        instance = this;


    }

    public GameObject itemdrop(Item item)
    {
        GameObject itemobj = Instantiate<GameObject>(itemprefab);

        itemobj.GetComponent<SpriteRenderer>().sprite = item.ItemImage;
        itemobj.GetComponent<Item_On_Floor>().thisitem = item;

        return itemobj;
    }

    public void itemget(Item item)
    {
        BagManager.instance.edititem(item);
    }

    public void itemget(GameObject itemobj)
    {
        Item item = itemobj.GetComponent<Item_On_Floor>().thisitem;
        BagManager.instance.edititem(item);
    }

}
