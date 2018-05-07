using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompingEnemies : MonoBehaviour
{
    [SerializeField]
    private LayerMask stompLayer;
    [SerializeField]
    private Transform stompCheck;
    [SerializeField]
    private AnimationClip death;
    [SerializeField]
    private GameObject stompArea;
    [SerializeField]
    private GameObject enemyToKill;
    private Animator anim;
    private float stompCheckRadius = 0.2f;
    private bool stompable = false;
    private EnemyPatrol enemyMove;
    private BoxCollider2D box;
    private PlayerMovement playerMove;
    // Use this for initialization
    private void Start ()
    {
        playerMove = FindObjectOfType<PlayerMovement>();
        box = GetComponent<BoxCollider2D>();
        enemyMove = GetComponent<EnemyPatrol>();
        anim = GetComponent<Animator>();
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
           
            StartCoroutine(Killed());
        }
    }
    IEnumerator Killed()
    {
        playerMove.enabled = false;
        anim.SetBool("IsKilled",true);
        enemyMove.enabled = false;
        box.enabled = false;
        stompArea.SetActive(false);
        yield return new WaitForSeconds(death.length);
        Destroy(enemyToKill);
        playerMove.enabled = true;
    }
}
