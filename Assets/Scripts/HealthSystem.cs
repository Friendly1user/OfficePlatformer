using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int Health = 3;
    private PlayerMovement playerMovement;
    private Rigidbody2D playerRb;
    public GameObject character;
    public bool isUnbreakable;
    public SpriteRenderer playerRend;
    public Animator damageAnim;

    private void Start()
    {
        playerMovement = character.GetComponent<PlayerMovement>();
        playerRb = character.GetComponent<Rigidbody2D>();
        playerRend = character.GetComponent<SpriteRenderer>();
        damageAnim = character.GetComponent<Animator>();
    }

    public void ChangeHealth(int healthOption)
    {
        Health += healthOption;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isUnbreakable)
        {
            ChangeHealth(-1);
            StartCoroutine("Unbreakable");
        }
    }

    public IEnumerator Unbreakable()
    {
        isUnbreakable = true;
        damageAnim.Play("DamageAnimation");
        yield return new WaitForSeconds(3);
        isUnbreakable = false;
    }
} 

