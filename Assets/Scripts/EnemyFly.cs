using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    public GameObject[] path;
    private float threshold;
    private int current;
    public GameObject mainchar;
    private bool patroling;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        threshold = 1;
        StartCoroutine("FlyPatrol");
        patroling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (patroling)
        {
            transform.position = Vector3.MoveTowards(transform.position, path[current].transform.position, Time.deltaTime * 3);
        }
        else
        {
            //transform.LookAt(mainchar.transform.position);
            //transform.position = Vector3.MoveTowards(transform.position, mainchar.transform.position, Time.deltaTime * 3);
        }
    }

    IEnumerator FlyPatrol()
    {
        while (true)
        {
            float d = Vector3.Distance(transform.position, path[current].transform.position);

            if (d < threshold)
            {
                current++;
                current %= path.Length;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            transform.LookAt(mainchar.transform.position);
            Instantiate(projectile, transform.position, transform.rotation);
            yield return new WaitForSeconds(4);
        }
        
    }   

    public void activateCoroutine()
    {
        //StopCoroutine("FlyPatrol");
        StartCoroutine("Shooting");
        //patroling = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            StopCoroutine(FlyPatrol());
            StopCoroutine("Shooting");
            Destroy(this.gameObject);
        }
    }
}
