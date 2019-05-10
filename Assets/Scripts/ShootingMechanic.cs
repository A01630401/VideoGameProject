using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanic : MonoBehaviour
{
    public Transform cannonTip;
    private Transform enemyPos;
    public GameObject bullet;
    private float speed = 3.0f;
    private Transform target;
    public AudioSource audioS;
    public AudioClip audioC;

    private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        audioS.clip = audioC;
        //enemyPos = enemy.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Shooting Mechanic: OnTriggerEnter");
        if (other.gameObject.layer == 9)
        {
            StartCoroutine(shooting());
        }
    }


    void OnTriggerStay(Collider other)
    {
        time += Time.deltaTime;
        //Debug.Log(time);
        if(other.gameObject.layer == 9)
        {   
            target = other.transform;
            transform.LookAt(target.transform);
            //Vector3 followPointPos = new Vector3(target.position.x, target.position.y, target.transform.position.z);
            //transform.position = Vector3.MoveTowards(transform.position, followPointPos, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        time = 0.0f;

    }
    
    
    IEnumerator shooting()
    {
        while(true)
        {
            audioS.Play();
            Instantiate(bullet, cannonTip);
            yield return new WaitForSeconds(1.0f);
        }
    }





}
