using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompingEnemies : MonoBehaviour
{
    [SerializeField]
    private LayerMask stompLayer;
    [SerializeField]
    private Transform stompCheck;

    private float stompCheckRadius = 0.2f;
    private bool stompable = false;
    // Use this for initialization
    private void Start ()
    {
        stompable = false;
	}
	// Update is called once per frame
	private void Update ()
    {
        Stomping();
    }
    private void Stomping()
    {
        stompable = Physics2D.OverlapCircle(stompCheck.position, stompCheckRadius, stompLayer);
        if (stompable == true)
        {
            Destroy(this.gameObject);
        }

        Debug.Log(stompable);
    }
}
