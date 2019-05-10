using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 50, ForceMode.Impulse);
        Destroy(this.gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
