using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Gem : MonoBehaviour, IInventoryItem
{
    public string nameOf;
    
    public string Name
    {
        get
        {
            return nameOf;
        }
    }

    public Sprite _Image;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {
        //Destroy(this);

    }

}
