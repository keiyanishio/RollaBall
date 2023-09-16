using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float countDown;

    public GameOver GameOverScreen;
    public void GameOver()
    {
        GameOverScreen.Setup();
    }
    // Update is called once per frame
    void Update()
    {
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
        }

        if (countDown < 11 && countDown > 1)
        {
            timerText.color = Color.red;
        }

        if (countDown < 0)
        {
            countDown = 0;
            GameOver();
        }
     
        int seconds = Mathf.FloorToInt(countDown % 60);
        timerText.text = string.Format("Time: {0:00}", seconds);
    }
}
