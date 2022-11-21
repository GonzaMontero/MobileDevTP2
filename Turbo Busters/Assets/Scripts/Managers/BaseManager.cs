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

    int playedBefore;

    void Awake()
    {
        base.Awake();
        pm = PlayerManager.instance;
        sm = SettingsManager.instance;

        var playerData = JsonUtility.FromJson<SavePlayerData>(PlayerPrefs.GetString("SavedPlayer"));

        if (playerData.playedBefore == 1)
        {
            pm.wasModified = true;
            pm.charactersBought = playerData.boughtItems;
            pm.currentPoints = playerData.points;
            sm.currentNeonColor = playerData.colorSelected;
            sm.currentVolume = playerData.volume;

        }
        else
            playedBefore = 1;
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

        PlayerPrefs.SetString("SavedPlayer", JsonUtility.ToJson(savedPlayer));
        PlayerPrefs.Save();
    }
}
