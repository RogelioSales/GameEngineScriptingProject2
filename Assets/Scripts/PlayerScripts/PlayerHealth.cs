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
    private GameObject hitImage;
    [SerializeField]
    private float flashSpeed;
    [SerializeField]
    private GameObject painImage;
    private PlayerMovement playerMovement;
    private LevelManager lvlManager;
    private bool isDead;
    private bool damaged;
    private GameObject enemy;
    private GameObject enemies;
    private GameObject enemy2;
    private void Awake()
    {
        lvlManager = FindObjectOfType<LevelManager>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemies = GameObject.FindGameObjectWithTag("Enemies");
        enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = maxHealth;

    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == enemy || collision.gameObject == enemies)
            StartCoroutine(Damaged());
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
        lvlManager.RespawnPlayer();
        isDead = false;
        playerMovement.enabled = true;
        healthSlider.value = maxHealth;
        currentHealth = maxHealth;
    }
    IEnumerator Damaged()
    {
        hitImage.SetActive(false);
        painImage.SetActive(true);
        yield return new WaitForSeconds(flashSpeed);
        painImage.SetActive(false);
        hitImage.SetActive(true);
    }
}
