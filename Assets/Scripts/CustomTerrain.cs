using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class CustomTerrain : MonoBehaviour {

    public Vector2 randomHeightRange = new Vector2(0, 0.1f);
    public Texture2D heightMapImage;
    public Vector3 heightMapScale = new Vector3(1, 1, 1);

    public bool shouldReset = true;

    //SINGLE PERLIN
    public float perlinXScale = 0.01f;
    public float perlinYScale = 0.01f;
    public int perlinOffsetX = 0;
    public int perlinOffsetY = 0;
    public int perlinOctaves = 3;
    public float perlinPersistance = 8;
    public float perlinHeightScale = 0.09f;

    //MULTIPLE PERLIN
    [System.Serializable]
    public class PerlinParameters {
        public float perlinXScale = 0.01f;
        public float perlinYScale = 0.01f;
        public int perlinOffsetX = 0;
        public int perlinOffsetY = 0;
        public int perlinOctaves = 3;
        public float perlinPersistance = 8;
        public float perlinHeightScale = 0.09f;
        public bool remove = false;
    }
    public List<PerlinParameters> perlinParameters = new List<PerlinParameters>() {
        new PerlinParameters()
    };

    // VORONOI
    public int voronoiPeakCount = 1;
    public float voronoiFalloff = 0.2f;
    public float voronoiDropoff = 0.6f;
    public float voronoiMinHeight = 0;
    public float voronoiMaxHeight = 0.4f;

    public Terrain terrain;
    public TerrainData terrainData;

    public void Voronoi() {
        float[, ] heightMap = GetHeightMap();

        for (int i = 0; i < voronoiPeakCount; i++) {
            Vector3 peak = new Vector3(
                Random.Range(0, terrainData.heightmapResolution),
                Random.Range(voronoiMinHeight, voronoiMaxHeight),
                Random.Range(0, terrainData.heightmapResolution)
            );

            heightMap[(int) peak.x, (int) peak.z] += peak.y;

            Vector2 peakLocation = new Vector2(peak.x, peak.z);
            float maxDistance = Vector2.Distance(new Vector2(0, 0), new Vector2(terrainData.heightmapResolution, terrainData.heightmapResolution));

            for (int y = 0; y < terrainData.heightmapResolution; y++) {
                for (int x = 0; x < terrainData.heightmapResolution; x++) {
                    if (!(x == peak.x && y == peak.y)) {
                        float distanceToPeak = Vector2.Distance(peakLocation, new Vector2(x, y)) / maxDistance;
                        float height = peak.y - distanceToPeak * voronoiFalloff - Mathf.Pow(distanceToPeak, voronoiDropoff);
                        if (heightMap[x, y] < height)
                            heightMap[x, y] = height;
                    }
                }
            }
        }
        terrainData.SetHeights(0, 0, heightMap);
    }
    public void Perlin() {
        float[, ] heightMap = GetHeightMap();
        for (int y = 0; y < terrainData.heightmapResolution; y++) {
            for (int x = 0; x < terrainData.heightmapResolution; x++) {
                heightMap[x, y] += Utils.fBM((x + perlinOffsetX) * perlinXScale, (y + perlinOffsetY) * perlinYScale, perlinOctaves, perlinPersistance) * perlinHeightScale;
            }
        }
        terrainData.SetHeights(0, 0, heightMap);
    }

    public void MultiplePerlinTerrain() {
        float[, ] heightMap = GetHeightMap();
        for (int y = 0; y < terrainData.heightmapResolution; y++) {
            for (int x = 0; x < terrainData.heightmapResolution; x++) {
                foreach (PerlinParameters p in perlinParameters) {
                    heightMap[x, y] += Utils.fBM((x + p.perlinOffsetX) * p.perlinXScale, (y + p.perlinOffsetY) * p.perlinYScale, p.perlinOctaves, p.perlinPersistance) * p.perlinHeightScale;
                }
            }
        }
        terrainData.SetHeights(0, 0, heightMap);
    }

    public void AddNewPerlin() {
        perlinParameters.Add(new PerlinParameters());
    }

    public void RemovePerlin() {
        List<PerlinParameters> keptPerlinParameters = new List<PerlinParameters>();
        for (int i = 0; i < perlinParameters.Count; i++) {
            if (!perlinParameters[i].remove) {
                keptPerlinParameters.Add(perlinParameters[i]);
            }
        }
        if (keptPerlinParameters.Count == 0) {
            keptPerlinParameters.Add(perlinParameters[0]);
        }
        perlinParameters = keptPerlinParameters;
    }

    public void RandomTerrain() {
        float[, ] heightMap = GetHeightMap();
        for (int x = 0; x < terrainData.heightmapResolution; x++) {
            for (int y = 0; y < terrainData.heightmapResolution; y++) {
                heightMap[x, y] += Random.Range(randomHeightRange.x, randomHeightRange.y);
            }
        }
        terrainData.SetHeights(0, 0, heightMap);
    }

    public void LoadTexture() {
        float[, ] heightMap = GetHeightMap();
        for (int x = 0; x < terrainData.heightmapResolution; x++) {
            for (int z = 0; z < terrainData.heightmapResolution; z++) {
                heightMap[x, z] += heightMapImage.GetPixel((int) (x * heightMapScale.x), (int) (z * heightMapScale.z)).grayscale * heightMapScale.y;
            }
        }
        terrainData.SetHeights(0, 0, heightMap);
    }

    public void ZeroOut() {
        float[, ] heightMap = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];
        for (int x = 0; x < terrainData.heightmapResolution; x++) {
            for (int y = 0; y < terrainData.heightmapResolution; y++) {
                heightMap[x, y] = 0;
            }
        }
        terrainData.SetHeights(0, 0, heightMap);
    }

    private float[, ] GetHeightMap() {
        if (shouldReset) {
            return new float[terrainData.heightmapResolution, terrainData.heightmapResolution];
        }
        return terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);
    }

    private void OnEnable() {
        Debug.Log("Initializing Terrain Data");
        terrain = this.GetComponent<Terrain>();
        terrainData = Terrain.activeTerrain.terrainData;
    }
    private void Awake() {
        SerializedObject tagManager = new SerializedObject(
            AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset") [0]
        );
        SerializedProperty tagsProperty = tagManager.FindProperty("tags");

        AddTag(tagsProperty, "Terrain");
        AddTag(tagsProperty, "Cloud");
        AddTag(tagsProperty, "Shore");

        tagManager.ApplyModifiedProperties();
        this.gameObject.tag = "Terrain";
    }

    void AddTag(SerializedProperty tagsProperty, string newTag) {
        bool found = false;
        for (int i = 0; i < tagsProperty.arraySize; i++) {
            SerializedProperty property = tagsProperty.GetArrayElementAtIndex(i);
            if (property.stringValue.Equals(newTag)) {
                found = true;
                break;
            }
        }
        if (!found) {
            tagsProperty.InsertArrayElementAtIndex(0);
            SerializedProperty newTagProperty = tagsProperty.GetArrayElementAtIndex(0);
            newTagProperty.stringValue = newTag;
        }
    }

    void Start() {

    }

    void Update() {

    }
}