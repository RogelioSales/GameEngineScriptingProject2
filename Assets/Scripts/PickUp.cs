using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private PlayerMovement player;

    private SpriteRenderer spriteRenderer;

    private CircleCollider2D circleCollider2D;

    // Use this for initialization
    void Start ()
    {     
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        { 
            player.DoubleJumped = false;
            spriteRenderer.enabled = false;
            circleCollider2D.enabled = false;
        }
    }
}
