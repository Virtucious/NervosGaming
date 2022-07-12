using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class web3Manager : MonoBehaviour
{
    string account;
    async void Start()
    {
#if UNITY_EDITOR
        account = "0x08A2475737e94d7a03C7985406e403Bbfe9CF969";
#else
        account = PlayerPrefs.GetString("Account");
#endif


        bool isInitialized = await Connector.Instance.isInitialized(account);


        
    }

    
    void Update()
    {
        
    }
}
