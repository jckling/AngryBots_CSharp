using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    public bool onlyPlayOnce = true;
    private bool playedOnce = false;

    private void OnTriggerEnter(Collider other)
    {
        if (playedOnce && onlyPlayOnce)
            return;

        GetComponent<AudioSource>().Play();
        playedOnce = true;
    }
}