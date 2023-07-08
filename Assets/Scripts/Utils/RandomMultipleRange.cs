using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMultipleRange
{
    public struct Range
    {
        public float min;
        public float max;
        public Range(float aMin, float aMax)
        {
            min = aMin; max = aMax;
        }
    }

    public static float RandomValueFromRanges(params Range[] ranges)
    {
        int RandomRangeToUse = Random.Range(0, ranges.Length);
        return Random.Range(ranges[RandomRangeToUse].min, ranges[RandomRangeToUse].max);
    }
}
