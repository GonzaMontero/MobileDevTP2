using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsEnabler : MonoBehaviour
{
    public Slider s;
    public TMP_Dropdown d;

    private void Awake()
    {

        s.value = SettingsManager.instance.currentVolume;
        d.value = ((int)SettingsManager.instance.currentNeonColor);

        s.onValueChanged.AddListener(delegate { ChangeVolume(s.value); });
        d.onValueChanged.AddListener(delegate { ChangeNeonColor(d.value); });
    }

    public void ChangeNeonColor(int color)
    {
        switch (color)
        {
            case 0:
                SettingsManager.instance.currentNeonColor = SettingsManager.neonColors.RED;
                break;
            case 1:
                SettingsManager.instance.currentNeonColor = SettingsManager.neonColors.GREEN;
                break;
            case 2:
                SettingsManager.instance.currentNeonColor = SettingsManager.neonColors.BLUE;
                break;
            default:
                SettingsManager.instance.currentNeonColor = SettingsManager.neonColors.RED;
                break;
        }
    }

    public void ChangeVolume(float volume)
    {
        SettingsManager.instance.currentVolume = volume;
    }
}
