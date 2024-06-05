using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMatarial : MonoBehaviour
{
    public Material terrainMaterial; // Terrain için kullanýlacak materyal

    private Terrain terrain;

    private void Start()
    {
        terrain = GetComponent<Terrain>();
        if (terrain != null && terrainMaterial != null)
        {
            terrain.materialTemplate = terrainMaterial;
        }
        else
        {
            Debug.LogWarning("Terrain veya materyal eksik!");
        }
    }
}
