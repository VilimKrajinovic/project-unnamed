﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {
    //fractal brownian motion
    public static float fBM(float x, float y, int octaves, float persistance) {
        float total = 0;
        float frequency = 1;
        float amplitude = 1;
        float maxValue = 0;
        for (int i = 0; i < octaves; i++) {
            total += Mathf.PerlinNoise(x * frequency, y * frequency) * amplitude;
            maxValue += amplitude;
            amplitude *= persistance;
            frequency *= 2;
        }
        return total / maxValue;
    }
}