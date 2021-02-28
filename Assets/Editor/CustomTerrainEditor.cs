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

    SerializedProperty randomHeightRange;
    SerializedProperty heightMapScale;
    SerializedProperty heightMapImage;
    SerializedProperty perlinXScale;
    SerializedProperty perlinYScale;
    SerializedProperty perlinOffsetX;
    SerializedProperty perlinOffsetY;

    bool showRandom = false;
    bool showLoadHeights = false;
    bool showPerlin = false;
    private void OnEnable() {
        randomHeightRange = serializedObject.FindProperty("randomHeightRange");
        heightMapScale = serializedObject.FindProperty("heightMapScale");
        heightMapImage = serializedObject.FindProperty("heightMapImage");
        perlinXScale = serializedObject.FindProperty("perlinXScale");
        perlinYScale = serializedObject.FindProperty("perlinYScale");
        perlinOffsetX = serializedObject.FindProperty("perlinOffsetX");
        perlinOffsetY = serializedObject.FindProperty("perlinOffsetY");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        CustomTerrain terrain = (CustomTerrain) target;

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
                        new Field { Property = perlinOffsetX, Min = 0, Max = 10000, SliderType = SliderType.INT },
                        new Field { Property = perlinOffsetY, Min = 0, Max = 10000, SliderType = SliderType.INT }
                    },
                    Buttons = new Dictionary<string, Action> { { "Generate perlin terrain", terrain.Perlin } }
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
        public SliderType? SliderType { get; set; }
        public float? Max { get; set; }
        public float? Min { get; set; }
    }

    enum SliderType {
        INT,
        FLOAT
    }

}