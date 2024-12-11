using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    private bool IsScore = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsScore == false && GetComponent<RectTransform>().anchoredPosition.x < -242)
        {
            GameManager.Instance.IncreaseScore();
            IsScore = true;
        }
    }
}
