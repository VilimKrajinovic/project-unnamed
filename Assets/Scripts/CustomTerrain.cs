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

    public float perlinXScale = 0.01f;
    public float perlinYScale = 0.01f;
    public int perlinOffsetX = 0;
    public int perlinOffsetY = 0;
    public int perlinOctaves = 3;
    public float perlinPersistance = 8;
    public float perlinHeightScale = 0.09f;

    public Terrain terrain;
    public TerrainData terrainData;

    private float[, ] GetHeightMap() {
        if (shouldReset) {
            return new float[terrainData.heightmapResolution, terrainData.heightmapResolution];
        }
        return terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);
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