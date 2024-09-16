using UnityEngine;
using UnityEditor;




[CustomEditor(typeof(LootManager))]
public class LootManagerEditor : Editor
{
    public override void OnInspectorGUI(){
        LootManager lootManager = (LootManager)target;
        
        var centerLabel = new GUIStyle(GUI.skin.label) {
            alignment = TextAnchor.MiddleCenter,
            fontSize = 18,
        };
        centerLabel.normal.textColor = Color.yellow;

        base.OnInspectorGUI();
        EditorGUILayout.Space(20);
        EditorGUILayout.LabelField("Loot Manager", centerLabel, GUILayout.ExpandWidth(true));
        EditorGUILayout.Space(10);


        EditorGUILayout.BeginHorizontal();
        
            if(GUILayout.Button("Sort Rarities")){
                lootManager.SortRarites();
            }
        
        EditorGUILayout.EndHorizontal();
        
        
        
        EditorGUILayout.Space(5);
        
        
        
        EditorGUILayout.BeginHorizontal();
        
            if(GUILayout.Button("Drop Loot")){
                lootManager.DropLoot(Vector3.zero);
            }
        
        EditorGUILayout.EndHorizontal();
    }
}
