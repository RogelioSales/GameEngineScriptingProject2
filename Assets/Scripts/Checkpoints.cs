using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private LevelManager lvlManager;
    private void Start()
    {
        lvlManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("NewSpawnpoint");
            lvlManager.CurrentSpawnPoint = this.gameObject;
        }
    }
}
