using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField]
    private Image keyImage;

    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2D;
    private bool collectedKey;
    

    // Use this for initialization
    private void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
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
            spriteRenderer.enabled = false;
            circleCollider2D.enabled = false;
            collectedKey = true;
            Debug.Log(collectedKey);
            IncentoryManager.HasKey = collectedKey;
        }
    }
}
