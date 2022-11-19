using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowerTimer : MonoBehaviour
{
    [Header("Timer Count Down")]
    public GameObject gameUIParent;
    public Image timerLine;
    public float totalTimeGiven = 7.0f;
    public bool shouldCountTime = true;

    [Header("Ending UI")]
    public GameObject loseGameParent;
    public TMPro.TextMeshProUGUI endGameText;

    [Header("Points")]
    public int totalPoints;
    public TMPro.TextMeshProUGUI pointsText;


    float timeRemaining;
    float totalTime;

    private void Start()
    {
        timeRemaining = totalTimeGiven;
        totalTime = 0;

        shouldCountTime = true;
    }

    private void Update()
    {
        totalTime += Time.deltaTime;

        if (!shouldCountTime) return;

        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerLine.fillAmount = timeRemaining / totalTimeGiven;
        }
        else
        {
            gameUIParent.SetActive(false);


            loseGameParent.SetActive(true);
            endGameText.text = "Total Time -" + totalTime;
        }
    }

    public void OnCollisionEvent()
    {
        timeRemaining = 0;
        shouldCountTime = true;

        totalPoints += 100;
        pointsText.text = totalPoints.ToString();
    }

    public void OnDragRelease()
    {
        timeRemaining = totalTimeGiven;
        shouldCountTime = false;
    }
}
