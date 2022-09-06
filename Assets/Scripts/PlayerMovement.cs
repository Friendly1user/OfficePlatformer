using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float horizontalInput;
    public float characterSpeed;
    public float jumpSpeed;
    public bool isOnFloor = true;
    public CharacterController controller;


    void Update()
    {
        var horizontalInput = new Vector2(Input.GetAxis("Horizontal"), 0);

        playerRb.velocity = horizontalInput * characterSpeed;

        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);
            isOnFloor = false;
        }
        if (Input.GetButtonUp("Jump") && playerRb.velocity.y > 0f)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * 0.5f);
            Debug.Log("up");
        }
        
        Debug.Log(playerRb.velocity);
            
            
        
        // playerRb.AddForce(Vector2.right * Time.deltaTime * horizontalInput * characterSpeed);

        /*if (Input.GetKeyDown(KeyCode.Space) && isOnFloor)
        {
            playerRb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isOnFloor = false;
        }*/

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isOnFloor = true;
        }

        if (other.gameObject.CompareTag("DeadPoint"))
        {
            Destroy(gameObject);
        }
    }
    
    
}
