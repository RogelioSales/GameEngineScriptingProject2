using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Damage : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 0.5f;
    [SerializeField]
    private int damageGiven;

    private GameObject player;
    PlayerHealth playerHealth;
    private float timer;
    private Animator anim;
    private bool inRange;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            anim.SetBool("IsAngry", true);
            inRange = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            anim.SetBool("IsAngry",false);
            inRange = false;
        }
    }

	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if(timer >= waitTime && inRange)
        {
            Attack();
        }
          
	}
    private void Attack()
    {
        timer = 0f;
        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakingDamage(damageGiven);
        }
    }
}
