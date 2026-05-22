using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

public class ItemManager : MonoBehaviour
{
   public static ItemManager Instance;

    public SOint coins;
    public TextMeshProUGUI uiTextCoins;


    private void Awake()
    {

        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

    }


    private void Start()
    {
        Reset();
    }
       

    

    private void Reset()
    {
        coins.Value = 0;
        UpdateUI();

    }

    public void AddCoins(int amount = 1)
    {
        coins.Value += amount;
    }

    private void UpdateUI()
    {
        //uiTextCoins.text = coins.ToString();
        //UIInGameManager.UpdateTextCoins(coins.Value.ToString());
    }

}
