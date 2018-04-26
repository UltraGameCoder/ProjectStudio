using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmoRenderShapeScript : MonoBehaviour {

    public List<GameObject> prefabs;

    public int selectedShape = 0;

    private void OnDrawGizmosSelected() {
        if(prefabs.Count <= 0) {
            return;
        }

        Gizmos.color = Color.red;
        GameObject prefab = prefabs[selectedShape];
        Mesh mesh = prefab.GetComponent<MeshFilter>().sharedMesh;
        Gizmos.DrawWireMesh(mesh, transform.position, prefab.transform.rotation);
    }
}
