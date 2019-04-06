using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeAndShieldManager : MonoBehaviour
{

    public Text lifeAndScoreText;

    private int life;
    private int shield;
    // Start is called before the first frame update
    void Start()
    {
        shield = 1;
        life = 1;

        UpdateTextUI();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
        {
            if (shield > 0)
            {
                shield--;
            }
            else
            {
                life--;
            }
        }
        
        if (collision.gameObject.layer == 13)
        {
            shield = 50;
            life = 10;
        }
        
        UpdateTextUI();

    }
    
    void UpdateTextUI()
    {
        lifeAndScoreText.text = "Life: " + life.ToString() + "\n" + "Shield: " + shield.ToString();
    }
}
