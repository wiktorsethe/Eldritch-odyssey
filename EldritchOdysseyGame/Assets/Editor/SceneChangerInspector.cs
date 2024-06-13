using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneChanger))]
public class SceneChangerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SceneChanger script = (SceneChanger)target;

        // Lista zawieraj�ca nazwy wszystkich scen w projekcie
        string[] sceneNames = new string[EditorBuildSettings.scenes.Length];
        for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
        {
            sceneNames[i] = System.IO.Path.GetFileNameWithoutExtension(EditorBuildSettings.scenes[i].path);
        }

        // Pobieranie indeksu obecnie wybranej sceny
        int selectedSceneIndex = System.Array.IndexOf(sceneNames, script.sceneName);

        // Wy�wietlanie listy rozwijanej z nazwami scen
        int newSelectedSceneIndex = EditorGUILayout.Popup("Scenes", selectedSceneIndex, sceneNames);

        // Aktualizacja wybranej nazwy sceny w skrypcie tylko wtedy, gdy wyb�r zosta� zmieniony
        if (newSelectedSceneIndex != selectedSceneIndex)
        {
            selectedSceneIndex = newSelectedSceneIndex;
            script.sceneName = sceneNames[selectedSceneIndex];
            // Powiadomienie Unity o zmianie, aby zapewni� aktualizacj� inspektora
            EditorUtility.SetDirty(target);
        }
    }
}
