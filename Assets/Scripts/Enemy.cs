using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject followPoint;
    private Vector3 followPointPos;
    private float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        followPoint = GameObject.Find("followPoint");
    }

    // Update is called once per frame
    void Update()
    {
        followPointPos = new Vector3(followPoint.transform.position.x, followPoint.transform.position.y, followPoint.transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, followPointPos, speed * Time.deltaTime);
    }
}
