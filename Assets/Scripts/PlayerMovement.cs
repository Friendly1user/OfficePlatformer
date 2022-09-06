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


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector2(horizontalInput * characterSpeed, playerRb.velocity.y);

        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);
            isOnFloor = false;
        }
        if (Input.GetButtonUp("Jump") && playerRb.velocity.y > 0f)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * 0.5f);
        }
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
