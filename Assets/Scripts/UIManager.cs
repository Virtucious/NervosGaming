using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public Animator startButton;
    public Animator menuButton;
    public Animator buildButton;

    public void StartGame()
    {
        SceneManager.LoadScene("2");
        startButton.SetBool("isHidden", true);
    }

    public void onActive()
    {
        menuButton.SetBool("onClick", true);
    }
    
    public void offActive()
    {
        menuButton.SetBool("onClick", false);
    }

    public void buildClick()
    {
        buildButton.SetBool("BuildClick", true);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
