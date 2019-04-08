using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 150, ForceMode.Impulse);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Layer:" + collision.gameObject.layer);
        if (collision.gameObject.layer == 10)
        {    
            Debug.Log("Collition on enemy layer 10");
            Destroy(collision.gameObject);
        }
    }
}
