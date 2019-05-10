using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class closeMechanis : MonoBehaviour
{
    public static bool newBullet = false;
    public GameObject TMPText;
    private MeshRenderer textMeshRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        newBullet = true;
        textMeshRenderer = TMPText.GetComponent<MeshRenderer>();
        textMeshRenderer.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            textMeshRenderer.enabled = true;
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            textMeshRenderer.enabled = false;
        }
    }
}
