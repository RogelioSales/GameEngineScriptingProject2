using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Text needKeyText;
    [SerializeField]
    private AnimationClip doorOpening;
    private Animator anim;
    private bool isOpened;


    private void Start()
    {
        anim = GetComponent<Animator>();
        needKeyText.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && isOpened == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            IncentoryManager.HasKey = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IncentoryManager.HasKey == true)
        {
            StartCoroutine(Opening());
        }
        else
        {
            needKeyText.enabled = true;
            StartCoroutine(ShowText());
        }
    }
    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(3.0f);
        needKeyText.enabled = false;
    }
    IEnumerator Opening()
    {
        anim.SetBool("Opening",true);
        yield return new WaitForSeconds(doorOpening.length);
        anim.SetBool("Opening", false);
        anim.SetBool("IsOpened", true);
        isOpened = true;
    }
}
