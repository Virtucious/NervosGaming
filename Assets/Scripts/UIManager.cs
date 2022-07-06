using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public Animator startButton;
    public Animator menuButton;
    
    public void StartGame()
    {
        SceneManager.LoadScene("2");
        startButton.SetBool("isHidden", true);
    }

    public void onActive()
    {
        menuButton.SetBool("onClick", true);
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
