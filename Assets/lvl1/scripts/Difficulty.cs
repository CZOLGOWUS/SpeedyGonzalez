﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty 
{

    static float secondsToMaxDifficulty = 60f;

    public static float GetDifficultyPrecent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }

}
