using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMechanic : MonoBehaviour
{
    private float speed;
    public Transform owner;
    private float threshold;
    private bool followingEnemy;
    public AudioSource aso;
    public AudioClip ac;
    // Start is called before the first frame update
    void Start()
    {
        aso.clip = ac;
        speed = 4.0f;
        threshold = 1.0f;
        followingEnemy = false;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(owner);
        if (!followingEnemy) {
            Vector3 followPointPos = new Vector3(owner.position.x - 3, transform.position.y, owner.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, followPointPos, speed * Time.deltaTime);
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.layer == 10) {
            followingEnemy = true;
            Transform target = other.transform;
            //transform.LookAt(target.transform);
            aso.Play();
            Vector3 followPointPos = new Vector3(target.position.x, transform.position.y, target.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, followPointPos, speed * Time.deltaTime);

            float d = Vector3.Distance(transform.position, target.position);

            Debug.Log("Distance" + d);
            if (d < threshold) {
                Destroy(other);
                followingEnemy = false;

            }
            
        }

    }
}
