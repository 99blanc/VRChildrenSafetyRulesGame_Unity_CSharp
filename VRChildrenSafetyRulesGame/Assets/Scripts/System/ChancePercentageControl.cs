using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChancePercentageControl : MonoBehaviour
{
    public static bool GetChanceResult(float chance)
    {
        int randomAccuracy = 10000000;
        float randomRange = chance * randomAccuracy;
        int random = UnityEngine.Random.Range(1, randomAccuracy + 1);

        if (chance < 0.0000001f)
        {
            chance = 0.0000001f;
        }
        if (random <= randomRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool GetChancePercentageResult(float percentageChance)
    {
        int randomAccuracy = 10000000;
        float randomRange = percentageChance * randomAccuracy;
        int random = UnityEngine.Random.Range(1, randomAccuracy + 1);

        if (percentageChance < 0.0000001f)
        {
            percentageChance = 0.0000001f;
        }

        percentageChance /= 100;

        if (random <= randomRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
