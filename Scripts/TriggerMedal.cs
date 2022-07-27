using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerMedal : MonoBehaviour
{
    [Header("References")]
    public Timer timerScript;
    public GameObject uiObject;
    public GameObject retryButton;
    public GameObject mainMenuButton;

    [SerializeField] private Image goldImage;
    [SerializeField] private Image silverImage;
    [SerializeField] private Image bronzeImage;
    [SerializeField] private Image noMedalImage;

    [SerializeField] private int goldTimer;
    [SerializeField] private int silverTimer;
    [SerializeField] private int bronzeTimer;

    /*
    void Start()
    {
        timerScript = GameObject.Find("Player").GetComponent<Timer>();
        timerScript.DestroyTimer();
    }
    */

    void OnTriggerEnter(Collider other)
    {
        if (timerScript && Time.time <= goldTimer)
        {
            goldImage.enabled = true;
        }

        else if (timerScript && Time.time <= silverTimer)
        {
            silverImage.enabled = true;
        }

        //else if (timerScript && Time.time <= bronzeTimer)
        else
        {
            bronzeImage.enabled = true;
        }

        /*
        else 
        {
            noMedalImage.enabled = true;
            uiObject.SetActive(false);
            retryButton.SetActive(true);
            mainMenuButton.SetActive(true);
        }
        */
    }



}