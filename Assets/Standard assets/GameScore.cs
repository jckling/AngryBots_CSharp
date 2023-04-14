﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameScore : MonoBehaviour
{
    private static GameScore instance;

    private static GameScore Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (GameScore)FindObjectOfType(typeof(GameScore));
            }

            return instance;
        }
    }

    void OnApplicationQuit()
    {
        instance = null;
    }

    public string playerLayerName = "Player", enemyLayerName = "Enemies";

    private int deaths = 0;
    private Dictionary<string, int> kills = new Dictionary<string, int>();
    private float startTime = 0.0f;

    public static int Deaths
    {
        get
        {
            if (Instance == null)
            {
                return 0;
            }

            return Instance.deaths;
        }
    }

#if !UNITY_FLASH
    public static ICollection<string> KillTypes
    {
        get
        {
            if (Instance == null)
            {
                return new string[0];
            }

            return Instance.kills.Keys;
        }
    }
#endif

    public static int GetKills(string type)
    {
        if (Instance == null || !Instance.kills.ContainsKey(type))
        {
            return 0;
        }

        return Instance.kills[type];
    }

    public static float GameTime
    {
        get
        {
            if (Instance == null)
            {
                return 0.0f;
            }

            return Time.time - Instance.startTime;
        }
    }

    public static void RegisterDeath(GameObject deadObject)
    {
        if (Instance == null)
        {
            Debug.Log("Game score not loaded");
            return;
        }

        int playerLayer = LayerMask.NameToLayer(Instance.playerLayerName),
            enemyLayer = LayerMask.NameToLayer(Instance.enemyLayerName);

        if (deadObject.layer == playerLayer)
        {
            Instance.deaths++;
        }
        else if (deadObject.layer == enemyLayer)
        {
            Instance.kills[deadObject.name] =
                Instance.kills.ContainsKey(deadObject.name) ? Instance.kills[deadObject.name] + 1 : 1;
        }
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
        if (startTime == 0.0f)
        {
            startTime = Time.time;
        }
    }
}