using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Numerics;

public class web3Manager : MonoBehaviour
{
    string account;
    
    public GameObject panel;
    public Button unClaimed;
    public TextMeshProUGUI uc;
    public TextMeshProUGUI tokens;
    public int unclaimedCoins = 0;
    public BigInteger coins = 0;
    private float waitTime = 2f;
    private float timer = 0f;



    async void Start()
    {
#if UNITY_EDITOR
        account = "0x08A2475737e94d7a03C7985406e403Bbfe9CF969";
#else
        account = PlayerPrefs.GetString("Account");
#endif

        bool isInitialized = await Connector.Instance.isInitialized(account);
        
        if (isInitialized == true)
        {
            panel.SetActive(false);
        }
        else
        {
           bool isContract = await Connector.Instance.InitializeContract();
            if (isContract == true)
            {
                panel.SetActive(false);
            }
        }
        
    }

    
    async void Update()
    {
        timer = Time.deltaTime;
         
        if (timer > waitTime)
        {
            unclaimedCoins += 1;
            uc.text = unclaimedCoins.ToString();
            timer = 0f;
        }

        uc.text = await Connector.Instance.getPending(account);
        if (unclaimedCoins == 100)
        {
            coins += await Connector.Instance.balanceOf(5);
            unclaimedCoins = 0;
            tokens.text = coins.ToString();
        }
        

        
        
    }

    public void isClicked()
    {
        
    }

}
