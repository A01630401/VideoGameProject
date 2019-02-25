using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    public Transform[] points;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {   
        transform.LookAt(points[i]);
        transform.position = Vector3.MoveTowards(transform.position, points[i].position, 3*Time.deltaTime);
        if (points[i].position == transform.position)
            i++;
        if (i == points.Length)
            i = 0;
    }
}
