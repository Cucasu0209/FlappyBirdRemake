using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] private Image[] Grounds;
    [SerializeField] private float GroundLimit;
    [SerializeField] private Image[] Clouds;
    [SerializeField] private float CloudLimit;

    private void Update()
    {
        foreach (var g in Grounds)
        {
            if (g.rectTransform.anchoredPosition.x < GroundLimit) g.rectTransform.anchoredPosition = new Vector2(-GroundLimit, g.rectTransform.anchoredPosition.y);
            g.rectTransform.anchoredPosition -= GameManager.Instance.GameSpeed * Vector2.right * Time.deltaTime;
        }

        foreach (var c in Clouds)
        {
            if (c.rectTransform.anchoredPosition.x < CloudLimit) c.rectTransform.anchoredPosition = new Vector2(-CloudLimit, c.rectTransform.anchoredPosition.y);
            c.rectTransform.anchoredPosition -= GameManager.Instance.GameSpeed * Vector2.right * Time.deltaTime;
        }
    }
}