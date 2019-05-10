using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiodog : MonoBehaviour
{
    public AudioSource aso;
    public AudioClip ac;
    // Start is called before the first frame update
    void Start()
    {
        aso.clip = ac;
        aso.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
