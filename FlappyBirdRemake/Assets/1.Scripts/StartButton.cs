using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button StartBtn;
    private void Start()
    {
        StartBtn.onClick.AddListener(() =>
        {
            StartBtn.interactable = false;
            StartBtn.transform.DOScale(0, 0.3f);
            GameManager.Instance.StartGame();
        });
        GameManager.Instance.OnRestartGame += OnRestart;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnRestartGame -= OnRestart;

    }

    private void OnRestart()
    {
        StartBtn.transform.localScale = Vector3.one;
        StartBtn.interactable = true;
    }
}
