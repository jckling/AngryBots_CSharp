using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ReBirth : MonoBehaviour
{
    private void Start()
    {
        AudioListener al = Camera.main.gameObject.GetComponent<AudioListener>();
        if (al)
        {
            AudioListener.volume = 1.0f;
        }

        ShaderDatabase sm = GetComponent<ShaderDatabase>();
        sm.WhiteIn();

        GetComponent<Camera>().backgroundColor = Color.white;
    }
}