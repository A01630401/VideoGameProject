using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cameras : MonoBehaviour
{
    public Camera CameraP1;
    public Camera CameraP2;

    // Start is called before the first frame update
    void Start()
    {
        ShowFirstPersonView();
    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            Debug.Log("Here");
            ShowOverheadView();
        }
        else
        {
            ShowFirstPersonView();
        }
    }

    public void ShowOverheadView()
    {
        CameraP2.enabled = true;
        CameraP1.enabled = false;
    }

    public void ShowFirstPersonView()
    {
        CameraP1.enabled = true;
        CameraP2.enabled = false;
    }
}
