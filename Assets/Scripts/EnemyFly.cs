using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    public GameObject[] path;
    private float threshold;
    private int current;
    private GameObject player;
    private bool patroling;
    public GameObject projectile;
    public AudioSource aso;
    public AudioClip ac;

    // Start is called before the first frame update
    void Start()
    {
        aso.clip = ac;
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
            aso.Play();
            transform.LookAt(player.transform.position);
            Vector3 positionForBullet = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z + 1);
            Instantiate(projectile, positionForBullet, transform.rotation);
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
        if (other.gameObject.layer == 9)
        {
            this.player = other.gameObject;
            activateCoroutine();
            //StopCoroutine(FlyPatrol());
            //StopCoroutine("Shooting");
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.layer == 9) {
            transform.LookAt(player.transform.position);
        }
    }
}
