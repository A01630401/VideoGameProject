using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMechanic : MonoBehaviour
{
    private Transform enemyPos;
    private float speed = 3.0f;
    private float time;
    public AudioSource audioS;
    public AudioClip audioC;


    // Start is called before the first frame update
    void Start()
    {
        audioS.clip = audioC;
        enemyPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            audioS.Play();
            Transform target = other.transform;
            enemyPos.LookAt(target.transform);

            Vector3 followPointPos = new Vector3(target.position.x, transform.position.y, target.transform.position.z);
            enemyPos.position = Vector3.MoveTowards(transform.position, followPointPos, speed * Time.deltaTime);
        }
    }

    


}
