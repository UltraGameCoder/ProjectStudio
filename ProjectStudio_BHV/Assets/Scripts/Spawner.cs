using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public List<GameObject> situationPrefabs;

    public List<GameObject> positions;

    // Use this for initialization
    void Start () {
        if(positions.Count <= 0) {
            print("Add more positions to the spawner!");
            return;
        }

        if(situationPrefabs.Count <= 0) {
            print("There are no registed situation prefabs in the spawner!");
            return;
        }
        foreach (GameObject prefab in situationPrefabs) {
            if(positions.Count <= 0) {
                print("There weren't enough registed locations inside the spawner to spawn all situationPrefabs!");
                break;
            }
            int i = Random.Range(0, positions.Count - 1);
            Transform trans = positions[i].transform;
            positions.RemoveAt(i);

            Instantiate(prefab, trans.position, trans.rotation);
        }
	}
}
