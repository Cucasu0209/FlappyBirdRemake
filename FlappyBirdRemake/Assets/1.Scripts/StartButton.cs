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
            StartBtn.transform.DOScale(0, 0.3f);
            GameManager.Instance.OnEndGame?.Invoke();
        });
    }
}
