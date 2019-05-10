using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiojump : MonoBehaviour
{
    public AudioSource aso;
    public AudioClip ac;
    // Start is called before the first frame update
    void Start()
    {
        aso.clip = ac;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            aso.Play();
        }
    }
}
