using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.AnimatedValues;
using ContradictiveGames.Managers;


namespace ContradictiveGames.Dev
{
    [CustomEditor(typeof(LootManager))]
    public class LootManagerEditor : Editor
    {
        AnimBool showDrops;
        LootManager lootManager;

        private void OnEnable(){
            showDrops = new AnimBool(true);
            showDrops.valueChanged.AddListener(Repaint);
            lootManager = (LootManager)target;
            lootManager.SortRarites();
        }
        
        public override void OnInspectorGUI(){

            
            int bigSpace = 20;
            
            var bigCenterLabel = new GUIStyle(GUI.skin.label) {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 18,
            };

            var centerLabel = new GUIStyle(GUI.skin.label){
                alignment = TextAnchor.MiddleCenter,
            };

            bigCenterLabel.normal.textColor = Color.yellow;

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Loot Manager", bigCenterLabel, GUILayout.ExpandWidth(true));
            EditorGUILayout.Space(bigSpace);
            
    #region Button Groups

            EditorGUILayout.BeginHorizontal();
            if(GUILayout.Button("Sort Rarities")){
                lootManager.SortRarites();
            }

            EditorGUILayout.Space(5);

            if(GUILayout.Button("Drop Loot")){
                lootManager.DropLoot(Vector3.zero);
            }
            EditorGUILayout.EndHorizontal();

    #endregion


            EditorGUILayout.Space(10);
            showDrops.target = EditorGUILayout.ToggleLeft("Show Drops", showDrops.target);
            EditorGUILayout.Space(5);

            if(EditorGUILayout.BeginFadeGroup(showDrops.faded)){
                EditorGUILayout.BeginVertical();
                float totalWeights = lootManager.Editor_GetTotalWeights();
                
                for(int i = 0; i < lootManager.rarities.Count; i++){
                    var cur = lootManager.rarities[i];
                    float pctDrop = cur.Weight / totalWeights * 100f;
                    var label = new GUIStyle(GUI.skin.label);
                    label.normal.textColor = cur.RarityColor;
                    EditorGUILayout.LabelField($"{cur.RarityName}: {Math.Round(pctDrop, 2)}% drop chance", label);
                }
                EditorGUILayout.Space(5);
                EditorGUILayout.LabelField($"Total weights: {totalWeights}", centerLabel);
                
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndFadeGroup();

            EditorGUILayout.Space(bigSpace);
            base.OnInspectorGUI();
            EditorGUILayout.Space(bigSpace);


        }
    }
}