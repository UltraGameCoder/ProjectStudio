using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;


[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor {

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        Spawner spawner = (Spawner)target;

        if(GUILayout.Button("Update")) {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("SpawnPoint");
            spawner.positions = new List<GameObject>();
            foreach(GameObject obj in objs) {
                spawner.positions.Add(obj);
            }
        }
    }
}
#endif
