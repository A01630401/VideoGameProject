using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private CharacterController cc;


    private MeshRenderer mr;

    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {

        cc = GetComponent<CharacterController>();
        mr = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float h = 5 * Input.GetAxisRaw("Horizontal");
        float v = 5 * Input.GetAxisRaw("Vertical");
        cc.SimpleMove(new Vector3(h, 0, v));

       

     
    }
    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if(item != null)
        {
            inventory.AddItem(item);

        }
    }

}
