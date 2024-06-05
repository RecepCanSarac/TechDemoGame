using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public float amplitude = 1.0f;
    public float length = 2.0f;  // 'lenght' corrected to 'length'
    public float speed = 1.0f;
    public float offset = 0.0f;

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
            offset -= Mathf.PI * 2;  // Sýnýrlama
        }
    }

    public float GetWaveHeight(float x)
    {
        return amplitude * Mathf.Sin(x / length + offset);
    }
}