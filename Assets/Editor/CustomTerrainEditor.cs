using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EditorGUITable;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomTerrain))]
[CanEditMultipleObjects]
public class CustomTerrainEditor : Editor {

    SerializedProperty shouldReset;
    SerializedProperty randomHeightRange;
    SerializedProperty heightMapScale;
    SerializedProperty heightMapImage;
    SerializedProperty perlinXScale;
    SerializedProperty perlinYScale;
    SerializedProperty perlinOffsetX;
    SerializedProperty perlinOffsetY;
    SerializedProperty perlinOctaves;
    SerializedProperty perlinPersistance;
    SerializedProperty perlinHeightScale;
    GUITableState perlinParametersTable;
    SerializedProperty perlinParameters;
    SerializedProperty voronoiPeakCount;
    SerializedProperty voronoiFalloff;
    SerializedProperty voronoiDropoff;
    SerializedProperty voronoiMinHeight;
    SerializedProperty voronoiMaxHeight;
    SerializedProperty voronoiType;

    bool showRandom = false;
    bool showLoadHeights = false;
    bool showPerlin = false;
    bool showMultiplePerlin = false;
    bool showVoronoi = false;
    private void OnEnable() {
        shouldReset = serializedObject.FindProperty("shouldReset");
        randomHeightRange = serializedObject.FindProperty("randomHeightRange");
        heightMapScale = serializedObject.FindProperty("heightMapScale");
        heightMapImage = serializedObject.FindProperty("heightMapImage");
        perlinXScale = serializedObject.FindProperty("perlinXScale");
        perlinYScale = serializedObject.FindProperty("perlinYScale");
        perlinOffsetX = serializedObject.FindProperty("perlinOffsetX");
        perlinOffsetY = serializedObject.FindProperty("perlinOffsetY");
        perlinOctaves = serializedObject.FindProperty("perlinOctaves");
        perlinPersistance = serializedObject.FindProperty("perlinPersistance");
        perlinHeightScale = serializedObject.FindProperty("perlinHeightScale");
        perlinParametersTable = new GUITableState("perlinParameterTable");
        perlinParameters = serializedObject.FindProperty("perlinParameters");
        voronoiPeakCount = serializedObject.FindProperty("voronoiPeakCount");
        voronoiFalloff = serializedObject.FindProperty("voronoiFalloff");
        voronoiDropoff = serializedObject.FindProperty("voronoiDropoff");
        voronoiMinHeight = serializedObject.FindProperty("voronoiMinHeight");
        voronoiMaxHeight = serializedObject.FindProperty("voronoiMaxHeight");
        voronoiType = serializedObject.FindProperty("voronoiType");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        CustomTerrain terrain = (CustomTerrain) target;

        EditorGUILayout.PropertyField(shouldReset);

        showRandom = EditorGUILayout.Foldout(showRandom, "Random");
        if (showRandom) {
            Render(new Context {
                Label = "Set heights between random values",
                    Fields = new List<Field> { new Field { Property = randomHeightRange } },
                    Buttons = new Dictionary<string, Action> { { "Random heights", terrain.RandomTerrain } }
            });
        }

        showLoadHeights = EditorGUILayout.Foldout(showLoadHeights, "Load heights");
        if (showLoadHeights) {
            Render(new Context {
                Label = "Load heights from texture",
                    Fields = new List<Field> {
                        new Field { Property = heightMapImage },
                        new Field { Property = heightMapScale }
                    },
                    Buttons = new Dictionary<string, Action> { { "Load texture", terrain.LoadTexture } }
            });
        }

        showPerlin = EditorGUILayout.Foldout(showPerlin, "Perlin noise terrain generator");
        if (showPerlin) {
            Render(new Context {
                Label = "Load perlin noise",
                    Fields = new List<Field> {
                        new Field { Property = perlinXScale, Min = 0, Max = 1, SliderType = SliderType.FLOAT },
                        new Field { Property = perlinYScale, Min = 0, Max = 1, SliderType = SliderType.FLOAT },
                        new Field { Property = perlinOffsetX, Min = 0, Max = 10000 },
                        new Field { Property = perlinOffsetY, Min = 0, Max = 10000 },
                        new Field { Property = perlinOctaves, Min = 1, Max = 10 },
                        new Field { Property = perlinPersistance, Min = 0.1f, Max = 10, SliderType = SliderType.FLOAT },
                        new Field { Property = perlinHeightScale, Min = 0, Max = 1, SliderType = SliderType.FLOAT },
                    },
                    Buttons = new Dictionary<string, Action> { { "Generate perlin terrain", terrain.Perlin } }
            });
        }

        showMultiplePerlin = EditorGUILayout.Foldout(showMultiplePerlin, "Multiple perlin");
        if (showMultiplePerlin) {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            GUILayout.Label("Multiple perlin noise", EditorStyles.boldLabel);
            perlinParametersTable = GUITableLayout.DrawTable(perlinParametersTable, perlinParameters);
            GUILayout.Space(20);
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("+")) {
                terrain.AddNewPerlin();
            }
            if (GUILayout.Button("-")) {
                terrain.RemovePerlin();
            }
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Apply multiple perlin")) {
                terrain.MultiplePerlinTerrain();
            }
        }

        showVoronoi = EditorGUILayout.Foldout(showVoronoi, "Voronoi");
        if (showVoronoi) {
            Render(new Context {
                Label = "Voronai noise",
                    Fields = new List<Field> {
                        new Field { Property = voronoiPeakCount, Min = 0, Max = 10 },
                        new Field { Property = voronoiFalloff, Min = 0, Max = 10f, SliderType = SliderType.FLOAT },
                        new Field { Property = voronoiDropoff, Min = 0, Max = 10f, SliderType = SliderType.FLOAT },
                        new Field { Property = voronoiMaxHeight, Min = 0, Max = 1f, SliderType = SliderType.FLOAT },
                        new Field { Property = voronoiMinHeight, Min = 0, Max = 1f, SliderType = SliderType.FLOAT },
                        new Field { Property = voronoiType }
                    },
                    Buttons = new Dictionary<string, Action> { { "Generate voronoi", terrain.Voronoi } }
            });
        }

        RenderDivider();
        if (GUILayout.Button("Zero out terrain")) {
            terrain.ZeroOut();
        }
        serializedObject.ApplyModifiedProperties();
    }

    private void Render(Context context) {
        RenderDivider();
        GUILayout.Label(context.Label, EditorStyles.boldLabel);
        if (context.Fields != null) {
            foreach (Field field in context.Fields) {
                if (field.Max != null && field.Min != null) {
                    switch (field.SliderType) {
                        case SliderType.FLOAT:
                            EditorGUILayout.Slider(field.Property, field.Min.Value, field.Max.Value);
                            break;
                        case SliderType.INT:
                            EditorGUILayout.IntSlider(field.Property, (int) field.Min.Value, (int) field.Max.Value);
                            break;
                        default:
                            break;
                    }
                } else {
                    EditorGUILayout.PropertyField(field.Property);
                }
            }
        }
        foreach (KeyValuePair<string, Action> entry in context.Buttons) {
            if (GUILayout.Button(entry.Key)) {
                entry.Value.Invoke();
            }
        }
    }

    private void RenderDivider() {
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
    }

    class Context {
        public string Label { get; set; }
        public IEnumerable<Field> Fields { get; set; }
        public Dictionary<string, Action> Buttons { get; set; }
    }

    class Field {
        public SerializedProperty Property { get; set; }
        public SliderType? SliderType { get; set; } = CustomTerrainEditor.SliderType.INT;
        public float? Max { get; set; }
        public float? Min { get; set; }
    }

    enum SliderType {
        INT,
        FLOAT
    }

}