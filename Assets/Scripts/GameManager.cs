using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public int score;
   public int best;
    [SerializeField] GameObject start;
    public static GameManager inst;
    private bool isGameStarted = false;

    [SerializeField] PlayerMovement playerMovement;
    public void IncrementScore()
    {
        score++;
       
        playerMovement.speed += playerMovement.speedIncreasePerPoint;

        if (score > best)
        {
            PlayerPrefs.SetInt("Highscore", score);
            best = score;
            
        }

    }
    private void Update()
    {
        if (MobileInput.Instance.Tap && !isGameStarted)
        {
            start.SetActive(false);
            isGameStarted = true;
            playerMovement.StartRunning();
        }
    }

    void Awake()
    {
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(gameObject);
        best = PlayerPrefs.GetInt("Highscore");
    }
}
