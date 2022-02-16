using UnityEngine;
using UnityEditor;

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