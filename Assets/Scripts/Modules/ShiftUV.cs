﻿using UnityEngine;

public class ShiftUV : MonoBehaviour
{
    public Vector2 offsetVector;

    void Start()
    {
    }

    void OnSignal()
    {
        GetComponent<Renderer>().material.mainTextureOffset += offsetVector;
    }
}