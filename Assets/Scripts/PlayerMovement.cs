using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float horizontalInput;
    public float characterSpeed;
    public float jumpSpeed;
    public bool isOnFloor = true;
    public Camera camera;
    public float characterDirection;


    void Update()
    {
        // Camera transform
        camera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 4f, camera.transform.position.z);

        // Main Movement logic
        CharacterMove();

        CharacterJump();

        CharacterDirection();
    }

    public void CharacterMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(horizontalInput * characterSpeed, playerRb.velocity.y);
    }

    public void CharacterJump()
    {
        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);
            isOnFloor = false;
            Debug.Log(playerRb.velocity);
        }
        if (Input.GetButtonUp("Jump") && playerRb.velocity.y > 0f)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * 0.5f);
        }
    }

    public void CharacterDirection()
    {
        float direction = horizontalInput;

        if (direction > 0)
        {
            transform.rotation = new Quaternion(0, 0,0,0);
            characterDirection = 1;
        }
        if (direction < 0)
        {
            transform.rotation = new Quaternion(0, 180,0,0);
            characterDirection = -1;
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
