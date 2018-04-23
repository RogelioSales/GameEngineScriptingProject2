using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    private AnimationClip pickUpReturn;
    private PlayerMovement player;
    private CircleCollider2D circleCollider2D;
    private Animator anim;
    private bool isUsed;
    private bool isReturning;

    // Use this for initialization
    private void Start ()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isUsed = true;
            isReturning = false;
            anim.SetBool("IsReturning", false);
            anim.SetBool("IsUsed", true);
            player.DoubleJumped = false;
            circleCollider2D.enabled = false;
            StartCoroutine(ResetPickUp());
        }
    }
    IEnumerator ResetPickUp()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        isUsed = false;
        isReturning = true;
        anim.SetBool("IsReturning",true);
        yield return new WaitForSeconds(pickUpReturn.length);
        circleCollider2D.enabled = true;
        anim.SetBool("IsUsed", false);
    }

}
