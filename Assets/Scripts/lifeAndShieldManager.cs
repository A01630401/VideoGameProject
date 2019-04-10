using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeAndShieldManager : MonoBehaviour
{

    public Text lifeAndScoreText;
    public GameObject partner;
    private int life;
    private int shield;
    private int partnerLife;
    private bool whithPartner;
    public Inventory inventory;
    
    
    // Start is called before the first frame update
    void Start()
    {
        shield = 0;
        life = 100;
        partnerLife = 0;
        UpdateTextUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (partner != null) {
            whithPartner = true;
        }
        else
        {
            whithPartner = false;
        }
    }


    private void medicineTaken()
    {
        if(life + 10 < 100)
        {
            life += 10;
        }
        else
        {
            life = 100;
        }
        
        
        if(shield + 20 < 80)
        {
            shield += 20;
        }
        else
        {
            shield = 80;
        }
        
        if (whithPartner)
        {
            if(partnerLife + 10 < 50)
            {
                partnerLife += 10;
            }
            else
            {
                life = 50;
            }

            UpdateTextUIWithPartner();
        }
        else
        {
            UpdateTextUI(); 
        }

    }
    


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
        {
            if (shield > 0)
            {
                shield-= 3;
                life--;
            }
            else
            {
                life-=5;
            }
            
            if (shield < 0)
            {
                shield = 0;
            }
        }
       
        if (!whithPartner)
        {
            UpdateTextUI();
        }
        else
        {
            UpdateTextUIWithPartner();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        
        
        if (other.gameObject.layer == 13  && Input.GetKeyDown(KeyCode.E))
        {
            IInventoryItem item = other.GetComponent<IInventoryItem>();
            
            if(item != null)
            {
                inventory.AddItem(item);

            }
            Destroy(other.transform.parent.gameObject);
            medicineTaken();
        }
    }
    
    

    void UpdateTextUI()
    {
        lifeAndScoreText.text = "Life: " + life.ToString() + "\n" + "Shield: " + shield.ToString();
    }
    
    void UpdateTextUIWithPartner()
    {
        lifeAndScoreText.text = "Life: " + life.ToString() + "\n" + "Shield: " + shield.ToString() + "\n" + "Friend: " + partnerLife.ToString();
    }
}
