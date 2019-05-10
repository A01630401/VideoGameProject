using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    private const int SLOTS = 5;

    private List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public Image medicine;
    public bool medicineflag;
    public Image dog;
    public bool dogflag;
    public Image shield;
    public bool shieldflag;
    public Image bullet;
    public bool bulletflag;
    public Image bulletPro;
    public bool bulletProflag;


    private void Start() {
        medicineflag = false;
    }

    public void AddItem(IInventoryItem item)
    {
        if (mItems.Count < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;

                mItems.Add(item);

                item.OnPickup();

                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }


    // E - medicina R - shield T - mascota Y - Bullet U - Buller pro

    public void takeMedicine() {
        medicine.enabled = true;
        medicineflag = true;
    }

    public void useMedicine() {
        medicineflag = false;
        medicine.enabled = false;
    }

        

    public void takeDog() {
        dog.enabled = true;
        dogflag = true;
    }

    public void useDog() {
        dog.enabled = false;
        dogflag = false;
    }


    public void takeShield() {
        shield.enabled = true;
        shieldflag = true;
    }

    public void useShield() {
        shield.enabled = false;
        shieldflag = false;
    }

    public void takeBullet() {
        bullet.enabled = true;
        bulletflag = true;
    }

    public void useBullet() {
        bullet.enabled = false;
        bulletflag = false;
    }

    public void takeBulletPro() {
        bulletPro.enabled = true;
        bulletProflag = true;
    }

    public void useBulletPro() {
        bulletPro.enabled = false;
        bulletProflag = false;
    }

}
