using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditorScript : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is responsible for creating and joining rooms.", MessageType.Info);
        RoomManager roomManager = (RoomManager)target;

        if(GUILayout.Button("Join Random Room")) {
            roomManager.JoinRandomRoom();
        }

        if(GUILayout.Button("Join Old West Map Random Room")) {
            roomManager.OnEnterButtonClicked_OldWest();
        }
        if(GUILayout.Button("Join Wizard Map Random Room")) {
            roomManager.OnEnterButtonClicked_Wizard();
        }
        if(GUILayout.Button("Join Castle Map Random Room")) {
            roomManager.OnEnterButtonClicked_Castle();
        }
    }
}
