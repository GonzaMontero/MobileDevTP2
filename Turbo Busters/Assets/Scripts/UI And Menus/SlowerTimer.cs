using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlowerTimer : MonoBehaviour
{
    [Header("Timer Count Down")]
    public GameObject gameUIParent;
    public Image timerLine;
    public float totalTimeGiven = 7.0f;
    public bool shouldCountTime = true;

    [Header("Ending UI")]
    public GameObject loseGameParent;
    public TextMeshProUGUI endGameText;

    [Header("Points")]
    public int totalPoints;
    public TextMeshProUGUI pointsText;


    float timeRemaining;
    float totalTime;

    private void Start()
    {
        pointsText.text = "0";

        timeRemaining = totalTimeGiven;
        totalTime = 0;

        shouldCountTime = true;

        GameObject.FindGameObjectWithTag("Main Player").GetComponent<DragControls>().onHitEvent.AddListener(OnCollisionEvent);
    }

    private void Update()
    {
        if (shouldCountTime)
        {
            totalTime += Time.deltaTime;
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerLine.fillAmount = timeRemaining / totalTimeGiven;
        }
        else
        {
            gameUIParent.SetActive(false);

            PlayerManager.instance.currentPoints += totalPoints;

            loseGameParent.SetActive(true);
            endGameText.text = "Total Time -" + totalTime;

            shouldCountTime = false;
        }
    }

    public void OnCollisionEvent()
    {
        timeRemaining = totalTimeGiven;
        shouldCountTime = true;

        totalPoints += 10;
        pointsText.text = totalPoints.ToString();

        if (totalPoints > 100)
            totalTimeGiven -= 1.5f;
        if(totalTimeGiven > 200)
            totalTimeGiven -= 1.5f;
    }
}
