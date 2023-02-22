using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour  
{
    public WaveSettings[] waveSettings;
}

[System.Serializable]
public class WaveSettings
{
    public int AmountEnemies;
}
