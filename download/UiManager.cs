using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text ScoreText;

    private void Update()
    {
        ScoreText.text = Convert.ToString(ScoreManager.Instance.Score);
    }
}
