using UnityEngine;
using UnityEditor;




[CustomEditor(typeof(LootManager))]
public class LootManagerEditor : Editor
{
    public override void OnInspectorGUI(){
        LootManager lootManager = (LootManager)target;
        
        base.OnInspectorGUI();

        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Sort Rarities")){
            lootManager.SortRarites();
        }
        EditorGUILayout.EndHorizontal();
    }
}
