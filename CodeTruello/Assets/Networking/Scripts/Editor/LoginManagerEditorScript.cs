using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LoginManager))]
public class LoginManagerEditorScript : Editor
{
    // this will be called whenever the inspector is drawn inside of unity
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is responsible for connecting to Photon Server.", MessageType.Info);
        LoginManager loginManager = (LoginManager)target;

        if(GUILayout.Button("Connect Anonymously")) {
            loginManager.ConnectAnonymously();
        }
    }
}
