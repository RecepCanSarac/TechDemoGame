using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class TerrainManager : MonoBehaviour
{
    private Terrain terrain;
    private TerrainData terrainData;
    private float[,] heights;
    public float terrainScale = 0.1f; // Terrain ölçeði, dalgalarýn geniþliðini ayarlamak için kullanýlýr

    private void Awake()
    {
        terrain = GetComponent<Terrain>();
        terrainData = terrain.terrainData;
        heights = terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);
    }

    private void Update()
    {
        for (int x = 0; x < terrainData.heightmapResolution; x++)
        {
            for (int z = 0; z < terrainData.heightmapResolution; z++)
            {
                float worldX = x * terrainData.size.x / terrainData.heightmapResolution;
                float worldZ = z * terrainData.size.z / terrainData.heightmapResolution;
                float waveHeight = WaveManager.instance.GetWaveHeight(worldX * terrainScale, worldZ * terrainScale);
                heights[x, z] = waveHeight / terrainData.size.y;
            }
        }

        terrainData.SetHeights(0, 0, heights);
    }
}
