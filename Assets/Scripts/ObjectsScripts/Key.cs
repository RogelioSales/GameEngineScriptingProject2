using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField]
    private Image keyImage;
    [SerializeField]
    private AnimationClip keyAnim;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private bool collectedKey;
    private Animator anim;
    private PlayerMovement playerMove;
    // Use this for initialization
    private void Start ()
    {
        playerMove = FindObjectOfType<PlayerMovement>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        collectedKey = false;       
    }
    private void Update()
    {
        if (collectedKey == true)
            keyImage.enabled = true;
        else
            keyImage.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(KeyAnimations());
        }
    }
    IEnumerator KeyAnimations()
    {
        playerMove.enabled = false;
        anim.SetTrigger("IsTouched");
        yield return new WaitForSeconds(keyAnim.length);
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;
        collectedKey = true;
        Debug.Log(collectedKey);
        IncentoryManager.HasKey = collectedKey;
        playerMove.enabled = true;

    }
}
