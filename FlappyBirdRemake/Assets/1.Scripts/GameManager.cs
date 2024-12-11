using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Action OnStartGame;
    public Action OnEndGame;
    private void Awake()
    {
        Instance = this;
    }
    public float GameSpeed = 75;
}
