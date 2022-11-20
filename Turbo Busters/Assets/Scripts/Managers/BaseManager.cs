using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavePlayerData
{
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
    
    void Start()
    {
        pm = PlayerManager.instance;
        sm = SettingsManager.instance;

        PlayerPrefs.DeleteAll();

        if (PlayerPrefs.HasKey("SavedPlayer"))
        {
            pm.wasModified = true;
            var playerData = JsonUtility.FromJson<SavePlayerData>(PlayerPrefs.GetString("SavedPlayer"));
            pm.charactersBought = playerData.boughtItems;
            pm.currentPoints = playerData.points;
            sm.currentNeonColor = playerData.colorSelected;
            sm.currentVolume = playerData.volume;

        }
    }

    private void OnApplicationQuit()
    {
        savedPlayer = new SavePlayerData()
        {
            volume = sm.currentVolume,
            colorSelected = sm.currentNeonColor,
            boughtItems = pm.charactersBought,
            points = pm.currentPoints
        };

        PlayerPrefs.SetString("SavedPlayer", JsonUtility.ToJson(savedPlayer));
        PlayerPrefs.Save();
    }
}
