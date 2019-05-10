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

    public Color damageColor;
    public Color healthColor;
    public Image damageImage;
    public int damageFlashSpeed;
    private bool damageFlag;

    public AudioSource aso;
    public AudioClip ac;

    // Start is called before the first frame update
    void Start()
    {
        aso.clip = ac;
        shield = 0;
        life = 100;
        partnerLife = 0;
        UpdateTextUI();
    }

    // Update is called once per frame
    void Update()
    {
        damage();
        if (partner != null) {
            whithPartner = true;
        }
        else
        {
            whithPartner = false;
        }

        if (life <= 0) {
            GameObject aux = GameObject.Find("SceneMan");
            ChangeScene auxScenemanager = aux.GetComponent<ChangeScene>();
            Destroy(aux);
            auxScenemanager.loadsScene(4);
        }

        checkingInvetory();
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

    private void shieldTaken() {
        if(shield + 20 < 80)
        {
            shield += 20;
        }
        else {
            shield = 80;
        }

        if (whithPartner) {
            UpdateTextUIWithPartner();
        }
        else {
            UpdateTextUI();
        }
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
        {
            Debug.Log("Colision");
            if (shield > 0)
            {
                shield-= 3;
                life--;
                damageFlag = true;
            }
            else
            {
                life-=5;
                damageFlag = true;
            }
            
            if (shield < 0)
            {
                shield = 0;
            }
            aso.Play();
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


    // E - medicina R - shield T - mascota Y - Bullet U - Buller pro

    private void checkingInvetory() {
        if (Input.GetKeyDown(KeyCode.E) && inventory.medicineflag) {
            inventory.useMedicine();
            medicineTaken();
        }

        if (Input.GetKeyDown(KeyCode.R) && inventory.shieldflag) {
            inventory.useShield();
            // shield taken
            shieldTaken();
        }

        if (Input.GetKeyDown(KeyCode.T) && inventory.dogflag) {
            inventory.useDog();
            // shield taken
        }

        if (Input.GetKeyDown(KeyCode.Y) && inventory.bullet) {
            inventory.useBullet();
            // shield taken
        }

        if (Input.GetKeyDown(KeyCode.Y) && inventory.bulletPro) {
            inventory.useBulletPro();
            // shield taken
        }
    }


    private void OnTriggerStay(Collider other)
    {
        
        
        if (other.gameObject.layer == 13  && Input.GetKeyDown(KeyCode.Z))
        {
            inventory.takeMedicine();
            Destroy(other.transform.parent.gameObject);
        }

        if (other.gameObject.layer == 16 && Input.GetKeyDown(KeyCode.Z)) {
            inventory.takeShield();
            Destroy(other.transform.parent.gameObject);
        }
    }


    public void damage() {
        if (damageFlag) {
            damageImage.color = healthColor;
        }
        else {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, damageFlashSpeed * Time.deltaTime);
        }

        damageFlag = false;
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
