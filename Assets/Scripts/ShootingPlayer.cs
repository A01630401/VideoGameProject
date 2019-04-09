using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    public GameObject bullet;
    public GameObject aim;
    // Start is called before the first frame update
    void Start()
    {
        //enemyPos = enemy.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = aim.transform.eulerAngles;
        
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform);
        }
       
    }


}
