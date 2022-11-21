using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavePlayerData
{
    public int playedBefore = 0;

    public float volume;
    public SettingsManager.neonColors colorSelected;

    public Dictionary<int, PlayerManager.BuyState> boughtItems;
    public int points;
}


public class BaseManager : SingletonBase<BaseManager>
{
    PlayerManager pm;
    SettingsManager sm;

    SavePlayerData savedPlayer;

    int playedBefore = 1;

    string datapath;

    void Awake()
    {
        base.Awake();
        pm = PlayerManager.instance;
        sm = SettingsManager.instance;

        datapath = Application.persistentDataPath + " data.bin";

        SavePlayerData playerData = FileSaveSystem<SavePlayerData>.LoadDataFromFile(datapath);

        if (playerData == null)
        {
            pm.SetStarterDictionary();
            return;
        }

        pm.charactersBought = playerData.boughtItems;
        pm.currentPoints = playerData.points;
        sm.currentNeonColor = playerData.colorSelected;
        sm.currentVolume = playerData.volume;
    }

    private void OnApplicationQuit()
    {
        savedPlayer = new SavePlayerData()
        {
            playedBefore = playedBefore,
            volume = sm.currentVolume,
            colorSelected = sm.currentNeonColor,
            boughtItems = pm.charactersBought,
            points = pm.currentPoints
        };

        FileSaveSystem<SavePlayerData>.SaveDataToFile(savedPlayer,datapath);
    }
}
