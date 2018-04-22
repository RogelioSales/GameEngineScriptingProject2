using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentSpawnPoint
    {
        get { return currentSpawnpoint; }
        set{ currentSpawnpoint = value; }
    }
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
