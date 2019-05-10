 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    public float mouseSensitivity;
    public float xAxisClamp;

    public Transform playerBody;
    public AudioClip ac;
    public AudioSource aso;

    private bool flagFall;
    
    // Start is called before the first frame update
    void Start()
    {
        flagFall = true;
        aso.clip = ac;
        lockCursor();
        xAxisClamp = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        camaraRotation();
        falling();
    }
    
    void lockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void camaraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;
        
        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            clampXAisRotationToValue(90.0f);
        } else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            clampXAisRotationToValue(270.0f);
        }

        transform.Rotate(Vector3.right * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    
    
    void clampXAisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    public void falling() {
        if (transform.position.y < -3) {
            // Cargar audio de caida
            Debug.Log("falling");
            if (flagFall) {
                flagFall = false;
                aso.Play();
            }
        }
    }
}
