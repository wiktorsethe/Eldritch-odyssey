using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BattleAction))]
public class BattleActionEditor : Editor
{
    SerializedProperty typeOfActionProp;
    SerializedProperty nameProp;
    SerializedProperty attackAmountProp;
    SerializedProperty defensePowerProp;
    SerializedProperty healAmountProp;
    
    void OnEnable()
    {
        typeOfActionProp = serializedObject.FindProperty("type");
        nameProp = serializedObject.FindProperty("actionName");
        attackAmountProp = serializedObject.FindProperty("attackAmount");
        defensePowerProp = serializedObject.FindProperty("defensePower");
        healAmountProp = serializedObject.FindProperty("healAmount");
    }
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(typeOfActionProp);
        EditorGUILayout.PropertyField(nameProp);

        BattleAction.TypeOfAction type = (BattleAction.TypeOfAction)typeOfActionProp.enumValueIndex;
    
        switch (type)
        {
            case BattleAction.TypeOfAction.ATTACK:
                EditorGUILayout.PropertyField(attackAmountProp);
                break;
            case BattleAction.TypeOfAction.DEFEND:
                EditorGUILayout.PropertyField(defensePowerProp);
                break;
            case BattleAction.TypeOfAction.SUPPORT:
                EditorGUILayout.PropertyField(healAmountProp);
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
