using UnityEngine;

public class DeactivatorOnLowQuality : MonoBehaviour
{
    public Quality qualityThreshhold = Quality.High;

    void Start()
    {
        if (QualityManager.quality < qualityThreshhold)
        {
            gameObject.SetActive(false);
        }

        enabled = false;
    }
}