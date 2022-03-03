using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text scoreText;
    public Text lifeText;
    public Button restartButton;

    public void SetScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetLifeText(int life)
    {
        lifeText.text = life.ToString();
    }

    public void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void HideRestartButton()
    {
        restartButton.gameObject.SetActive(false);
    }
}
