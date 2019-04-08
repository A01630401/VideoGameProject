using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMechanic : MonoBehaviour
{
    public Transform enemyPos;
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
        if (other.gameObject.layer == 9)
        {
            Transform target = other.transform;
            enemyPos.LookAt(target.transform);

            Vector3 followPointPos = new Vector3(target.position.x, target.position.y, target.transform.position.z);
            enemyPos.position = Vector3.MoveTowards(transform.position, followPointPos, speed * Time.deltaTime);
        }
    }

    


}
