using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaterManager : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Mesh mesh;
    private Vector3[] baseVertices;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        baseVertices = mesh.vertices;  }

    private void Update()
    {
        Vector3[] vertices = new Vector3[baseVertices.Length];

        float baseX = transform.position.x;

        for (int i = 0; i < vertices.Length; i++)
        {
            float waveHeight = WaveManager.instance.GetWaveHeight(baseX + baseVertices[i].x);
            vertices[i] = baseVertices[i];
            vertices[i].y = waveHeight;
        }

        mesh.vertices = vertices;

        // Performans için normals hesaplamayý azalt
        if (Time.frameCount % 10 == 0)
        {
            mesh.RecalculateNormals();
        }
    }
}
