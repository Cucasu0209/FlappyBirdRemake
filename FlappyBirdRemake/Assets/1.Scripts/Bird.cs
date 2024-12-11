using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private RectTransform Rect;
    private bool Flying = false;
    private float yVeloc = 0;
    private bool CanControl;
    [SerializeField] private float Gravity = -9.8f;
    [SerializeField] private float JumpForce = 100;
    void Start()
    {
        Flying = false;
        Rect = GetComponent<RectTransform>();
        GameManager.Instance.OnStartGame += OnStartGame;
        GameManager.Instance.OnRestartGame += OnRestartGame;

    }

    private void OnStartGame()
    {
        CanControl = true;
        Flying = true;
        Jump();
    }
    private void OnRestartGame()
    {
        CanControl = true;
        Flying = false;
        yVeloc = 0;
        Rect.anchoredPosition = new Vector2(Rect.anchoredPosition.x, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    void Update()
    {
        if (Flying)
        {
            if (GameManager.Instance.IsOnGame) yVeloc += Gravity * Time.deltaTime;
            else yVeloc += Gravity * 4 * Time.deltaTime;
            Rect.anchoredPosition += Vector2.up * yVeloc * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(yVeloc / JumpForce * 50, -90, 50));

            if (Input.GetMouseButtonDown(0) && CanControl)
            {
                Jump();
            }
        }
    }
    private void Jump()
    {
        yVeloc = JumpForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.IsOnGame)
        {
            GameManager.Instance.EndGame();
            //Flying = false;
            yVeloc = JumpForce * 2.5f;
            CanControl = false;

        }

    }
}
