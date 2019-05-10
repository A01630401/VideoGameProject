using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet2 : MonoBehaviour
{
    private Rigidbody rb;
    public AudioSource aso;
    public AudioClip ac;

    // Start is called before the first frame update
    void Start()
    {
        aso.clip = ac;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 150, ForceMode.Impulse);
        Destroy(gameObject, 1);
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
            aso.Play();
            Debug.Log("Collition on enemy layer 10");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        } else if (collision.gameObject.layer == 15) {
            Debug.Log("collision.gameObject.layer == 15");
            collision.gameObject.GetComponent<Boss>().dead();
            Destroy(this.gameObject);
        }
    }
}
