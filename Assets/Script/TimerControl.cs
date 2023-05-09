using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerControl : MonoBehaviour
{
    public Text timerTxt;
    public float time = 125f;
    public static float selectCountdown;
    public static bool stop = false;

    void Start()
    {
        selectCountdown = time;
    }

    void Update()
    {
        if(stop)
        {
            if (Mathf.Floor(selectCountdown) <= 0)
            {
                SceneManager.LoadScene("Fail");
            }
            else
            {
                selectCountdown -= Time.deltaTime;
                timerTxt.text = "Timer : " + Mathf.Floor(selectCountdown).ToString();
            }
        }
    }
}
