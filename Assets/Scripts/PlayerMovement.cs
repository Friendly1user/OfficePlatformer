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
    public float spaceSpeed;
    public bool isOnFloor;
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        playerRb.AddForce(Vector2.right * Time.deltaTime * horizontalInput * characterSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && isOnFloor)
        {
            playerRb.AddForce(Vector2.up * spaceSpeed, ForceMode2D.Impulse);
            isOnFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isOnFloor = true;
        }
    }
}
