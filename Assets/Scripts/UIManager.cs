using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text highscoreText;

    void Update()
    {
        highscoreText.text = "BEST: " + GameManager.inst.best;
        scoreText.text = "SCORE: " + GameManager.inst.score;
    }
}
