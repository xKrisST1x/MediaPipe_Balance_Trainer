using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class BreathTracker : MonoBehaviour
{
    int breathPressure;
    int limit = 550;

    string message;

    //string inString = "Inhaling";
    //string exString = "Exhaling";

    float breathRate = 3f;
    
    bool inhaling;

    float inhaleCounter;
    float exhaleCounter;

    float inhaleCountdown;
    float exhaleCountdown;

    [SerializeField] TMP_Text inExText;
    //[SerializeField] TMP_Text countInhaleText;
    //[SerializeField] TMP_Text countExhaleText;

    [SerializeField] GameObject inhaleParent;
    [SerializeField] GameObject exhaleParent;

    [SerializeField] GameObject[] inhaleLights;
    [SerializeField] GameObject[] exhaleLights;

    [SerializeField] AudioSource gongSource;
    [SerializeField] AudioClip gongClip;

    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            inhaling = true;
        }
        else
        {
            inhaling = false;
        }
        */

        if (breathPressure < limit)
        {
            inhaling = true;
        }
        else
        {
            inhaling = false;
        }

        if (inhaling == true)
        {
            exhaleCounter = 0;
            exhaleCountdown = 3;

            inhaleCounter += Time.deltaTime;
            inhaleCountdown -= Time.deltaTime;

            /* Countdown timer 
            if (inhaleCountdown <= 0)
            {
                countInhaleText.text = "0.00";
            }
            else
            {
                countInhaleText.text = inhaleCountdown.ToString("0.00");
            }
            */

            CountdownLights(inhaleCountdown, inhaleLights);
        }

        if (inhaling == false)
        {
            inhaleCounter = 0;
            inhaleCountdown = 3;

            exhaleCounter += Time.deltaTime;
            exhaleCountdown -= Time.deltaTime;

            /* Countdown timer
            if (exhaleCountdown <= 0)
            {
                countExhaleText.text = "0.00";
            }
            else
            {
                countExhaleText.text = exhaleCountdown.ToString("0.00");
            }
            */

            CountdownLights(exhaleCountdown, exhaleLights);
        }

        if (inhaleCounter > breathRate)
        {
            inExText.text = "Exhale";
            //countInhaleText.gameObject.SetActive(false); Countdown timer
            //countExhaleText.gameObject.SetActive(true); Countdown timer
            inhaleParent.SetActive(false);
            exhaleParent.SetActive(true);
        }
        else if (exhaleCounter > breathRate)
        {
            inExText.text = "Inhale";
            //countExhaleText.gameObject.SetActive(false); Countdown timer
            //countInhaleText.gameObject.SetActive(true); Countdown timer
            exhaleParent.SetActive(false);
            inhaleParent.SetActive(true);
        }

        Debug.Log(breathPressure);
    }

    void CountdownLights(float countdown, GameObject[] light)
    {
        for (int i = 0; i < light.Length; i++)
        {
            light[i].SetActive(false);
        }

        if (countdown >= 2f)
        {
            light[0].SetActive(true);
            light[1].SetActive(false);
            light[2].SetActive(false);
            light[3].SetActive(false);

            gongSource.PlayOneShot(gongClip);
        }
        else if (countdown < 2f && countdown >= 1f)
        {
            light[0].SetActive(true);
            light[1].SetActive(true);
            light[2].SetActive(false);
            light[3].SetActive(false);

            gongSource.PlayOneShot(gongClip);
        }
        else if (countdown < 1f && countdown >= 0f)
        {
            light[0].SetActive(true);
            light[1].SetActive(true);
            light[2].SetActive(true);
            light[3].SetActive(false);

            gongSource.PlayOneShot(gongClip);
        }
        else if (countdown < 0f)
        {
            light[0].SetActive(false);
            light[1].SetActive(false);
            light[2].SetActive(false);
            light[3].SetActive(true);

            gongSource.PlayOneShot(gongClip);
        }
    }

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        //Debug.Log("Arrived: " + msg);
        int.TryParse(msg, out breathPressure);
    }
    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
