using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    public GameObject bullet;
    public GameObject aim;
    public GameObject bullet2;
    public AudioClip shootclip;
    public AudioSource shootsource;
    // Start is called before the first frame update
    void Start()
    {
        shootsource.clip = shootclip;
        //enemyPos = enemy.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = aim.transform.eulerAngles;
        
        if (Input.GetMouseButtonDown(0))
        {
            shootsource.Play();
            if (closeMechanis.newBullet) {
                Debug.Log("New Bullet");
                Instantiate(bullet2, transform);
            }
            else {
                Instantiate(bullet, transform);
            }
        }
       
    }


}
