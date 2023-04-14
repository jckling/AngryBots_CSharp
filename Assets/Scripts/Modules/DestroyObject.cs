using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject objectToDestroy;

    void OnSignal()
    {
        Spawner.Destroy(objectToDestroy);
    }
}