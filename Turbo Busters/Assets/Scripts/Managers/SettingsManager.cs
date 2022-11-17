using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : SingletonBase<SettingsManager>
{
    public enum neonColors { RED = 0, GREEN, BLUE };
    public neonColors currentNeonColor = neonColors.RED;

    [Range(0, 1)]
    public float currentVolume = 0.5f;
}
