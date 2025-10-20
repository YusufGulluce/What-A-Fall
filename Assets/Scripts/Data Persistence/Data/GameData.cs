using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{

    public float highScore;
    public bool OnOff;

    public GameData()
    {
        this.highScore = 0;
        this.OnOff = true;
    }
}
