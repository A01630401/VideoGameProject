using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanic : MonoBehaviour
{
    public Transform cannonTip;
    public Transform enemyPos;
    public GameObject bullet;
    private float speed = 3.0f;

    private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        //enemyPos = enemy.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        time += Time.deltaTime;
        //Debug.Log(time);
        if(other.gameObject.layer == 9)
        {   
            Transform target = other.transform;
            enemyPos.LookAt(target.transform);
            if (time >= 2)
            {
                Instantiate(bullet, cannonTip);
                time = 0.0f;
            }
            
            Vector3 followPointPos = new Vector3(target.position.x, target.position.y, target.transform.position.z);
            enemyPos.position = Vector3.MoveTowards(transform.position, followPointPos, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        time = 0.0f;

    }





}
