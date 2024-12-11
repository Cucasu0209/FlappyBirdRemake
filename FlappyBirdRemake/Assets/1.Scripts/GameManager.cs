using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Action OnRestartGame;
    public Action OnStartGame;
    public Action OnEndGame;
    public Action OnScoreChange;

    public bool IsOnGame = false;
    public int Score = 0;

    private void Awake()
    {
        Instance = this;
    }
    public float GameSpeed = 75;
    public void StartGame()
    {
        ResetScore();
        IsOnGame = true;
        OnStartGame?.Invoke();
    }
    public void EndGame()
    {
        IsOnGame = false;
        OnEndGame?.Invoke();
        DOVirtual.DelayedCall(2, RestartGame);
    }
    public void RestartGame()
    {
        OnRestartGame?.Invoke();

    }
    public void ResetScore()
    {
        Score = 0;
        OnScoreChange?.Invoke();
    }
    public void IncreaseScore()
    {
        Score++;
        OnScoreChange?.Invoke();
    }
}
