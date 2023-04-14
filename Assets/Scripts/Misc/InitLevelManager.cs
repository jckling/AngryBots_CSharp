using UnityEngine;
using UnityEngine.SceneManagement;

public class InitLevelManager : MonoBehaviour
{
    public Texture2D splash;

    private Texture2D background;
    private bool loading = true;

    void Start()
    {
        background = new Texture2D(2, 2);
        background.SetPixels(new Color[] { Color.black, Color.black, Color.black, Color.black });
        background.Apply();

        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(Application.loadedLevel + 1);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        loading = false;
    }

    void OnGUI()
    {
        if (!loading)
        {
            return;
        }

        float splashWidth = splash.width, splashHeight = splash.height;

        if (splashWidth > Screen.width)
        {
            float scale = Screen.width / splashWidth;
            splashWidth *= scale;
            splashHeight *= scale;
        }

        GUI.DrawTexture(new Rect(0.0f, 0.0f, Screen.width, Screen.height), background);

        GUI.DrawTexture(
            new Rect(
                (Screen.width - splashWidth) * 0.5f,
                (Screen.height - splashHeight) * 0.5f,
                splashWidth,
                splashHeight
            ),
            splash
        );
    }
}