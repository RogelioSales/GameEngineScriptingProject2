using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private Image hitImage;
    //  [SerializeField]
    //   private AudioClip 
    [SerializeField]
    private float flashSpeed;
    [SerializeField]
    private Color flashColor = Color.white;


   // private Animator anim;
    // private AudioSource
    private PlayerMovement playerMovement;
    private LevelManager lvlManager;
    private bool isDead;
    private bool damaged;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    private void Update ()
    {
        if (damaged)
            hitImage.color = flashColor;
        else
            hitImage.color = Color.Lerp(hitImage.color, Color.clear, flashSpeed * Time.deltaTime);
        damaged = false;	
	}
    public void TakingDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
            Death();
    }
    private void Death()
    {
        isDead = true;
        playerMovement.enabled = false;
    }

}
