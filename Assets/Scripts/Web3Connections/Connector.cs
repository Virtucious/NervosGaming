using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using System.Numerics;

public class Connector : MonoBehaviour
{
    public static Connector Instance;
    
    public async void Start()
    {
        //string account = "0xABA02F8052aC1DebAebDe8B73E2338cFC85a182F";
        //await isInitialized(account);
        Instance = this;
    }


    public async Task<bool> isInitialized(string account)
    {
        string initializeMethod = "isInitialized";
        string[] obj = { account };
        string getAllowanceArgs = JsonConvert.SerializeObject(obj);

        string allowance = await EVM.Call(ChainConfig.chain,
            ChainConfig.network,
            ChainConfig.contractAddress,
            ChainConfig.abi,
            initializeMethod,
            getAllowanceArgs,
            ChainConfig.rpc);
        print(allowance);
        return (allowance == "true");
    }

    public async Task<string> getPending(string account)
    {
        string initializeMethod = "getPending";
        string[] obj = { account };
        string getAllowanceArgs = JsonConvert.SerializeObject(obj);

        string allowance = await EVM.Call(ChainConfig.chain,
            ChainConfig.network,
            ChainConfig.contractAddress,
            ChainConfig.abi,
            initializeMethod,
            getAllowanceArgs,
            ChainConfig.rpc);
        print(allowance);
        return allowance;
    }

    public async Task<bool> InitializeContract()
    {
        string increaseAllowanceMethod = "initialize";
        string[] obj = { };
        string increaseAllowanceArgs = JsonConvert.SerializeObject(obj);
        try
        {
            string transactionHash = await Web3GL.SendContract(increaseAllowanceMethod,
            ChainConfig.abi,
            ChainConfig.contractAddress,
            increaseAllowanceArgs,
            "0"
            );
            string status = await GetTansactionStatus(transactionHash);
            return (status == "success") ? true : false;
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            return false;
        }
    }

    public async Task<bool> buyTower(int code)
    {
        string increaseAllowanceMethod = "buyTower" +
            "";
        string[] obj = { code.ToString() };
        string increaseAllowanceArgs = JsonConvert.SerializeObject(obj);
        try
        {
            string transactionHash = await Web3GL.SendContract(increaseAllowanceMethod,
            ChainConfig.abi,
            ChainConfig.contractAddress,
            increaseAllowanceArgs,
            "0"
            );
            string status = await GetTansactionStatus(transactionHash);
            return (status == "success") ? true : false;
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            return false;
        }
    }

    public async Task<bool> claimTokens()
    {
        string increaseAllowanceMethod = "claimTokens";
        string[] obj = { };
        string increaseAllowanceArgs = JsonConvert.SerializeObject(obj);
        try
        {
            string transactionHash = await Web3GL.SendContract(increaseAllowanceMethod,
            ChainConfig.abi,
            ChainConfig.contractAddress,
            increaseAllowanceArgs,
            "0"
            );
            string status = await GetTansactionStatus(transactionHash);
            return (status == "success") ? true : false;
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            return false;
        }
    }

    public async Task<BigInteger> balanceOf(int tokenId)
    {
#if UNITY_EDITOR
        string account = "0xABA02F8052aC1DebAebDe8B73E2338cFC85a182F";
#else
        string account = PlayerPrefs.GetString("Account");
#endif
        return await ERC1155.BalanceOf(
            ChainConfig.chain, 
            ChainConfig.network,
            ChainConfig.contractAddress,
            account,
            tokenId.ToString(),
            ChainConfig.rpc);
    }

    public async Task<string> GetTansactionStatus(string txn)
    {
        string status = await EVM.TxStatus(ChainConfig.chain,
            ChainConfig.network,
            txn,
            ChainConfig.rpc);
        while (!(status == "success" || status == "fail"))
        {
            status = await EVM.TxStatus(ChainConfig.chain,
            ChainConfig.network,
            txn,
            ChainConfig.rpc);
        }
        return status;
    }
}
