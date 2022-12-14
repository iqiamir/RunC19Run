using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finish = false;

    // Start is called before the first frame update
    void Awake()
    {
        startTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        if (finish)
            return;

        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    public void Rewards()
    {
        finish = true;
        timerText.color = Color.yellow;

        
    }
}
