using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneLister : MonoBehaviour
{
    [MenuItem("Tools/List All Scenes")]
    public static void ListAllScenes()
    {
        string[] scenePaths = GetAllScenePaths();

        foreach (string scenePath in scenePaths)
        {
            Debug.Log(scenePath);
        }
    }

    public static string[] GetAllScenePaths()
    {
        int sceneCount = EditorBuildSettings.scenes.Length;
        string[] scenePaths = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            scenePaths[i] = EditorBuildSettings.scenes[i].path;
        }

        return scenePaths;
    }
}
