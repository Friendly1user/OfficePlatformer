using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;

    private void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 2), transform.rotation);
        }
    }
}
