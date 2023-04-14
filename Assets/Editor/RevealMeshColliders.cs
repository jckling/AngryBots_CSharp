using UnityEngine;
using UnityEditor;

public class RevealMeshCollider : ScriptableObject
{
    [MenuItem("Tools/Reveal Mesh Colliders")]
    static void DoRecord()
    {
        GameObject[] objs = Selection.gameObjects;
        foreach (GameObject obj in objs)
        {
            if (obj.GetComponent<MeshCollider>())
            {
                Debug.Log("MESH COLLIDER FOUND @ " + obj.name, obj.transform);
            }
        }
    }
}