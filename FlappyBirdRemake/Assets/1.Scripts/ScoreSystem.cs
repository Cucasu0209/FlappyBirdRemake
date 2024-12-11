using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI ScoreDisplay;


    private void Start()
    {
        GameManager.Instance.OnScoreChange += OnScoreChange;
    }

    private void OnScoreChange()
    {
        ScoreDisplay.SetText(GameManager.Instance.Score.ToString());
    }
}
