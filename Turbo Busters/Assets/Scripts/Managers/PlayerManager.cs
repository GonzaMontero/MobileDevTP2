using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonBase<PlayerManager>
{
    [System.Serializable]
    public enum BuyState {Bought=0, NotBought }

    public Dictionary<int, BuyState> charactersBought = new Dictionary<int, BuyState>();

    public int currentPoints;

    public GameObject[] characterPrefabList;

    public GameObject selectedGO;

    public bool wasModified = false;

    public void SetStarterDictionary()
    {
        charactersBought.Add(0, BuyState.Bought);
        charactersBought.Add(1, BuyState.NotBought);
        charactersBought.Add(2, BuyState.NotBought);
        charactersBought.Add(3, BuyState.NotBought);
    }
}
