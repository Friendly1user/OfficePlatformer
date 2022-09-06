using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BulletBehavour : MonoBehaviour
{
    private ShootingSystem _shootingSystem;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _shootingSystem = GameObject.FindWithTag("Player").GetComponent<ShootingSystem>();
        _playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();


        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(_playerMovement.characterDirection, 0.5f) * _shootingSystem.bulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
       
    }
}

