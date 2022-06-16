using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{ 
    Tool, Food 
}

[System.Serializable]
public class Item
{
    public Type type;

    public Item(Item item)
    {
        this.type = item.type;
    }
        //public int value;
}
