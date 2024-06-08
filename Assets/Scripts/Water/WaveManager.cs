using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public float amplitude = 1.0f;
    public float length = 2.0f;
    public float speed = 1.0f;
    public float offset = 0.0f;

    public float perlinScale = 0.1f;
    public int waveCount = 3;

    public float sinAmplitude = 2.0f;
    public float sinFrequency = 0.2f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
        if (offset > Mathf.PI * 2)
        {
            offset -= Mathf.PI * 2;
        }
    }

    public float GetWaveHeight(float x, float z)
    {
        float y = 0;
        float frequency = 0.5f;
        float amplitudeSum = 0;

        for (int i = 0; i < waveCount; i++)
        {
            float perlinValue = Mathf.PerlinNoise((x * frequency + offset) * perlinScale, (z * frequency + offset) * perlinScale) * 2 - 1;
            y += perlinValue * amplitude / (i + 1);
            amplitudeSum += amplitude / (i + 1);
            frequency *= 2;
        }

        y += sinAmplitude * Mathf.Sin(x * sinFrequency + offset) + sinAmplitude * Mathf.Sin(z * sinFrequency + offset);

        return y;
    }
}
