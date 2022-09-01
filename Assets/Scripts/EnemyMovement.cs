using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    public float direction = 1;
    
    void Update()
    {
        transform.Translate(new Vector2(direction,0) * Time.deltaTime * enemySpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (direction)
        {
            case 1:
                direction = -1;
                break;
            case -1:
                direction = 1;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeadPoint"))
        {
            Destroy(gameObject);
        }
        
        Debug.Log("DESTROY");
        
        
    }
}
