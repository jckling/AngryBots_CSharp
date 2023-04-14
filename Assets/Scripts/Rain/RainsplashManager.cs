using UnityEngine;

public class RainsplashManager : MonoBehaviour
{
    public int numberOfParticles = 700;
    public float areaSize = 40.0f;
    public float areaHeight = 15.0f;
    public float fallingSpeed = 23.0f;
    public float flakeWidth = 0.4f;
    public float flakeHeight = 0.4f;
    public float flakeRandom = 0.1f;

    public Mesh[] preGennedMeshes;
    private int preGennedIndex = 0;

    public bool generateNewAssetsOnStart = false;
}