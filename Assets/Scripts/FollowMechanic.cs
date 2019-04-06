using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMechanic : MonoBehaviour
{

    public GameObject followPoint;
    private Transform target;
    private float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        target = followPoint.transform;
    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followPointPos = new Vector3(target.position.x, target.position.y, target.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, followPointPos, speed * Time.deltaTime);
    }
}
