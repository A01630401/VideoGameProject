using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMechanic : MonoBehaviour
{
    private float speed;
    public Transform owner;
    private float threshold;
    private bool followingEnemy;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4.0f;
        threshold = 1.0f;
        followingEnemy = false;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(owner);
        if (!followingEnemy) {
            Vector3 followPointPos = new Vector3(owner.position.x - 3, owner.position.y, owner.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, followPointPos, speed * Time.deltaTime);
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.layer == 10) {
            followingEnemy = true;
            Transform target = other.transform;
            transform.LookAt(target.transform);

            Vector3 followPointPos = new Vector3(target.position.x, target.position.y, target.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, followPointPos, speed * Time.deltaTime);

            float d = Vector3.Distance(transform.position, target.position);

            if (d < threshold) {
                Destroy(other.gameObject);
                followingEnemy = false;
            }
            
        }

    }
}
