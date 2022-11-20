using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavePlayerData
{
    public int isFirst = 0;

    public float volume;
    public SettingsManager.neonColors colorSelected;

    public Dictionary<int, PlayerManager.BuyState> boughtItems;
}


public class BaseManager : SingletonBase<BaseManager>
{
    PlayerManager pm;
    SettingsManager sm;

    SavePlayerData savedPlayer;

    int firstBoot = 1;
    
    void Start()
    {
        pm = PlayerManager.instance;
        sm = SettingsManager.instance;

        var playerData = JsonUtility.FromJson<SavePlayerData>(PlayerPrefs.GetString("SavedPlayer"));

        if(playerData.isFirst != firstBoot)
        {
            pm.wasModified = false;
        }
        else
        {
            pm.wasModified = true;
            pm.charactersBought = playerData.boughtItems;
            sm.currentNeonColor = playerData.colorSelected;
            sm.currentVolume = playerData.volume;
        }
    }

    private void OnApplicationQuit()
    {
        savedPlayer = new SavePlayerData()
        {
            isFirst = 1,
            volume = sm.currentVolume,
            colorSelected = sm.currentNeonColor,
            boughtItems = pm.charactersBought
        };

        PlayerPrefs.SetString("SavedPlayer", JsonUtility.ToJson(savedPlayer));
        PlayerPrefs.Save();
    }
}
