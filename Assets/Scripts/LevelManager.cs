using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject currentSpawnpoint;

    private PlayerMovement player;
	// Use this for initialization
	private void Start ()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
	}
    public void RespawnPlayer()
    {
        player.transform.position = currentSpawnpoint.transform.position;
    }
}
