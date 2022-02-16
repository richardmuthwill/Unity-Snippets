using UnityEngine;
using UnityEditor;

/*
  Hide objects in the editor by adding the tag "HideInEditor" to GameObjects
*/

[InitializeOnLoad]
public class Autorun
{
    static Autorun()
    {
        EditorApplication.update += Update;
    }

    static void Update()
    {
        SceneVisibilityManager.instance.Hide(GameObject.FindGameObjectsWithTag("HideInEditor"), true);
    }
}
