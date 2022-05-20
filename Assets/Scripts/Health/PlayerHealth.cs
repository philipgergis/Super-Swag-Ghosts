using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : ParentHealth
{

    // [SerializeField] protected int max_health = 100; // can be overrided for variation


    // sets max health to current health
    void Awake()
    {
        curr_health = max_health;
        //Debug.Log(curr_health);
        is_down = false;
    }

    // subtract damage from current health
    // protected override void TakeDamage(int damage)
    // {
    //     curr_health -= damage;
    // }

    //when collides with a ghost, player's health falls to 0 and player can't move
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            if(curr_health != 0)
            {
                TakeDamage(100);
                GetComponent<HunterController>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                is_down = false;
                //Debug.Log(curr_health);
            }
            else {is_down = true;}
        }
    }
}
