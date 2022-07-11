using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{

    public Animator startButton;
    public Animator menuButton;
    public Animator buildButton;
    
    public GameObject castle;
    public GameObject barracks;
    public GameObject cannons;

    public LayerMask whatCanBeClickedOn;
    
    public bool buildCastle;
    public bool buildBarrack;
    public bool buildCannon;
    
    public TextMeshProUGUI Pow;
    
    public int pow =0;
    private int castleNumber = 0;
    

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

    public void castleBuild()
    {
        buildButton.SetBool("BuildClick", true);
        buildCastle = true;
    }

    public void barrackBuild()
    {
        buildButton.SetBool("BuildClick", true);
        buildBarrack = true;
    }

    public void cannonBuild()
    {
        buildButton.SetBool("BuildClick", true);
        buildCannon = true;
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (buildCastle == true && Input.GetMouseButtonDown(0) && castleNumber <= 1)
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(myRay, out hit, 100f, whatCanBeClickedOn))
            {
                if (hit.collider.tag != "castle")
                {
                    Instantiate(castle, hit.point, Quaternion.identity);
                }
            }

            pow += 20;
            string Power = pow.ToString();
            Pow.text = Power;
            castleNumber++;
            buildCastle = false;
            buildButton.SetBool("BuildClick", false);
        }

        if (buildBarrack == true && Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(myRay, out hit, 100f, whatCanBeClickedOn))
            {
                Instantiate(barracks, hit.point, Quaternion.AngleAxis(-90, cannons.transform.right));
            }

            pow += 5;
            string Power = pow.ToString();
            Pow.text = Power;
            buildBarrack = false;
            buildButton.SetBool("BuildClick", false);
        }

        if (buildCannon == true && Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(myRay, out hit, 100f, whatCanBeClickedOn))
            {
                Instantiate(cannons, hit.point, Quaternion.identity);
            }

            pow += 10;
            string Power = pow.ToString();
            Pow.text = Power;
            buildCannon = false;
            buildButton.SetBool("BuildClick", false);
        }
    }
}
