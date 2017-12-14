using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    // Script is added to floors that represent rooms. Walls will be generated.
    private GameObject WallPrefab;
    private GameObject DoorPrefab;

    void Start () {
        // Get prefabs
        WallPrefab = PrefabManager.GetPrefab("Wall");
        DoorPrefab = PrefabManager.GetPrefab("Door");

        // We need to add the walls. 
        // Every room is a square, so there are two walls to add.
        float height_offset = WallPrefab.GetComponent<MeshFilter>().sharedMesh.bounds.size.y/2f;
        float left_offset = transform.lossyScale.x/2f;
        float right_offset = transform.lossyScale.y/2f;

        GameObject left_wall = Instantiate(WallPrefab, transform);
        GameObject right_wall = Instantiate(WallPrefab, transform);

        // Name
        left_wall.name = "Left Wall";
        right_wall.name = "Right Wall";

        // Rotate
        left_wall.transform.Rotate(new Vector3(90, 0, 90), Space.World);
        right_wall.transform.Rotate(new Vector3(-90, 0, 0), Space.World);

        // Move
        left_wall.transform.Translate(new Vector3(-left_offset, height_offset, 0), Space.World);
        right_wall.transform.Translate(new Vector3(0, height_offset, -right_offset), Space.World);
    }

    void Hole(bool door) {

    }
}
