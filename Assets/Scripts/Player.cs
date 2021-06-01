using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponet;
    
   
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if space is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
       
    }
    private void FixedUpdate()
    {
        rigidbodyComponet.velocity = new Vector3(horizontalInput, rigidbodyComponet.velocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f,playerMask).Length ==0)
        {
            return;
        }
        if (jumpKeyWasPressed)
        {
            rigidbodyComponet.AddForce(Vector3.up * 6, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
        
    }
   
}
