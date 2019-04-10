using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The GameObject is made to bounce using the space key.
// Also the GameOject can be moved forward/backward and left/right.
// Add a Quad to the scene so this GameObject can collider with a floor.

public class CharacterControl : MonoBehaviour
{
    public float movementSpeed = 6.0f;
    public AnimationCurve jumpFallOff;
    public float jumpMultiplier;
    
    private CharacterController playerController;
    private bool isJumping;
    
    public Inventory inventory;

    void Start()
    {
        playerController = GetComponent<CharacterController>();

        // let the gameObject fall down
        //gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update()
    {
        playerMove();
    }
    
    void playerMove()
    {

        //Debug.Log(Input.GetAxis("Horizontal"));
        //Debug.Log(Input.GetAxis("Vertical"));
        float horizontalInput = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        Vector3 fowardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;

        playerController.SimpleMove(fowardMovement + rightMovement);
        //Debug.Log(fowardMovement + rightMovement);


        jumpInput();
    }
    
    void jumpInput()
    {
        if(Input.GetKeyDown("space") && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }
    
    private IEnumerator JumpEvent()
    {
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            playerController.Move(Vector3.up * jumpForce * jumpMultiplier *Time.deltaTime);
            timeInAir += Time.deltaTime;

            yield return null;
            
        } while (!playerController.isGrounded && playerController.collisionFlags != CollisionFlags.Above);

        isJumping = false;
    }
    
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        Debug.Log(hit.gameObject.name);
        if(item != null)
        {
            inventory.AddItem(item);
            Destroy(hit.gameObject);

        }
    }
} 