using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI TimeTextUI;
    public TextMeshProUGUI date;
    public TextMeshProUGUI china;
    public TextMeshProUGUI france;
    public TextMeshProUGUI brazil;
    public TextMeshProUGUI singapore;
    public UnityEngine.UI.Image secUI;
    public int sec;
    public int timeCurrent;

    void Start()
    {
        sec = DateTime.Now.Second;
        timeCurrent = sec;
        InvokeRepeating("RunEffect", 1, 1);

    }
    void SetTime()
    {
        TimeTextUI.text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
        date.text = DateTime.Now.DayOfWeek.ToString() + " " + DateTime.Now.Day.ToString() + " " + DateTime.Now.ToString("MMMM");

        var ChTimeZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
        DateTime ChTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, ChTimeZone);
        china.text = Convert.ToString(ChTime.Hour+":"+ChTime.Minute);

        var euTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
        DateTime euTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, euTimeZone);
        france.text = Convert.ToString(euTime.Hour+":"+euTime.Minute);

        var siTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
        DateTime siTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, siTimeZone);
        singapore.text = Convert.ToString(siTime.Hour + ":" + siTime.Minute);
    }
    void RunEffect()
    {
        timeCurrent++;
        //StartCoroutine(TimeRun());
        if (timeCurrent == 60)
        {
            timeCurrent = 0;
        }
        secUI.fillAmount = (float)timeCurrent / 60;
    }
    IEnumerator TimeRun()
    {
        yield return new WaitForSeconds(1);
        timeCurrent++;
    }
    // Update is called once per frame
    void Update()
    {
        SetTime();
        //RunEffect();
    }
}
