using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomGenerator))]
public class RoomGeneratorEditor : Editor
{
    public override void OnInspectorGUI() {
        RoomGenerator RoomGen = (RoomGenerator)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Generate Nodes")) {
            RoomGen.GenerateRoomInEditor();
        }

        if(GUILayout.Button("Generate Mesh")) {
            RoomGen.GenerateMesh();
        }
    }
}
