using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    private float patrolSpeed;
    [SerializeField]
    private float distance;
    [SerializeField]
    private Transform groundCheck;

    private bool movingRight = true;
	// Update is called once per frame
	private void Update ()
    {
        transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);
        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position ,Vector2.down, distance);
        if (ground.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0,180,0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
	}
}
