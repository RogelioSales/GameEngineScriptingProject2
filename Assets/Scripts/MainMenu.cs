using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPanel;
    [SerializeField]
    private GameObject howToPanel;
    [SerializeField]
    private GameObject quitPanel;
    [SerializeField]
    private GameObject creditsPanel;
	// Use this for initialization
	void Start ()
    {
        buttonPanel.SetActive(true);
        howToPanel.SetActive(false);
        quitPanel.SetActive(false);
        creditsPanel.SetActive(false);
	}
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        buttonPanel.SetActive(false);
        quitPanel.SetActive(true);
    }
    public void Ok()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Cancel()
    {
        quitPanel.SetActive(false);
        buttonPanel.SetActive(true);
    }
    public void HowTo()
    {
        buttonPanel.SetActive(false);
        howToPanel.SetActive(true);
    }
    public void Continue()
    {
        howToPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    public void Back()
    {
        creditsPanel.SetActive(false);
        howToPanel.SetActive(true);
    }
    public void Leave()
    {
        howToPanel.SetActive(false);
        creditsPanel.SetActive(false);
        buttonPanel.SetActive(true);
    }
}
