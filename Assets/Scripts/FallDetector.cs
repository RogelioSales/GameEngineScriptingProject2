using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    private LevelManager lvlManager;
    private bool fell;
    private void Start()
    {
        lvlManager = GameObject.FindObjectOfType<LevelManager>();   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            lvlManager.RespawnPlayer();             
    }
}
