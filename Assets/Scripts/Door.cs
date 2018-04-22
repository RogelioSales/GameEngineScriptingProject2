using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Text needKeyText;

    private void Start()
    {
        needKeyText.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IncentoryManager.HasKey == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            IncentoryManager.HasKey = false;
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
}
