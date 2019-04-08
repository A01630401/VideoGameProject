using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    public Transform cannonTip;
    public GameObject bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        //enemyPos = enemy.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, cannonTip);
        }
       
    }


}
