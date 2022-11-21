using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavePlayerData
{
    public Dictionary<int, PlayerManager.BuyState> boughtItems;
    public int points;
}


public class BaseManager : SingletonBase<BaseManager>
{
    PlayerManager pm;

    SavePlayerData savedPlayer;

    string datapath;

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    void Awake()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    {
        base.Awake();
        pm = PlayerManager.instance;

        datapath = Application.persistentDataPath + "GameData.bin";

        SavePlayerData playerData = FileSaveSystem<SavePlayerData>.LoadDataFromFile(datapath);

        if (playerData == null)
        {
            pm.SetStarterDictionary();
            return;
        }

        pm.charactersBought = playerData.boughtItems;
        pm.currentPoints = playerData.points;
    }

    private void OnApplicationQuit()
    {
        savedPlayer = new SavePlayerData()
        {
            boughtItems = pm.charactersBought,
            points = pm.currentPoints
        };

        FileSaveSystem<SavePlayerData>.SaveDataToFile(savedPlayer,datapath);
    }
}
