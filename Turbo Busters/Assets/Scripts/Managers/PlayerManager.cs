using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonBase<PlayerManager>
{
    public enum BuyState {Bought=0, NotBought }

    public Dictionary<int, BuyState> charactersBought = new Dictionary<int, BuyState>();

    public GameObject[] characterPrefabList;

    public bool wasModified = false;

    private void Start()
    {
        if (wasModified) return;

        charactersBought.Add(0, BuyState.Bought);
        charactersBought.Add(1, BuyState.NotBought);
        charactersBought.Add(2, BuyState.NotBought);
        charactersBought.Add(3, BuyState.NotBought);
    }


    void OnBuyScreenLoad()
    {

    }

}
