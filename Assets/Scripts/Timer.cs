using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float countDown;

    // Update is called once per frame
    void Update()
    {
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        else if (countDown < 0)
        {
            countDown = 0;
            timerText.color = Color.red;
        }
     
        int seconds = Mathf.FloorToInt(countDown % 60);
        timerText.text = string.Format("Time: {0:00}", seconds);
    }
}
