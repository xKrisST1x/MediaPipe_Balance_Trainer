using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class BreathTracker : MonoBehaviour
{
    int breathPressure;
    int limit = 565;

    float breathRate = 3f;
    
    bool inhaling;

    float inhaleCounter;
    float exhaleCounter;

    float inhaleCountdown;
    float exhaleCountdown;

    [SerializeField] TMP_Text inExText;

    [SerializeField] GameObject inhaleParent;
    [SerializeField] GameObject exhaleParent;

    [SerializeField] GameObject[] inhaleLights;
    [SerializeField] GameObject[] exhaleLights;

    void Update()
    {
<<<<<<< Updated upstream
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
        
=======
>>>>>>> Stashed changes
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

            CountdownLights(inhaleCountdown, inhaleLights);
        }

        if (inhaling == false)
        {
            inhaleCounter = 0;
            inhaleCountdown = 3;

            exhaleCounter += Time.deltaTime;
            exhaleCountdown -= Time.deltaTime;

            CountdownLights(exhaleCountdown, exhaleLights);
        }

        if (inhaleCounter > breathRate)
        {
            inExText.text = "Exhale";
            inhaleParent.SetActive(false);
            exhaleParent.SetActive(true);
        }
        else if (exhaleCounter > breathRate)
        {
            inExText.text = "Inhale";
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
        }
        else if (countdown < 2f && countdown >= 1f)
        {
            light[0].SetActive(true);
            light[1].SetActive(true);
            light[2].SetActive(false);
            light[3].SetActive(false);
        }
        else if (countdown < 1f && countdown >= 0f)
        {
            light[0].SetActive(true);
            light[1].SetActive(true);
            light[2].SetActive(true);
            light[3].SetActive(false);
        }
        else if (countdown < 0f)
        {
            light[0].SetActive(false);
            light[1].SetActive(false);
            light[2].SetActive(false);
            light[3].SetActive(true);
        }
    }

    void OnMessageArrived(string msg)
    {
        int.TryParse(msg, out breathPressure);
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
