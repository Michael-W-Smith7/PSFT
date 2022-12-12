using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private GameObject collection;
    [SerializeField] private TMP_Text timer;

    private float clock;
    private bool play;

    void Awake()
    {
        collection = GameObject.Find("collection");
    }

    void Update()
    {
        if(play)
        {
            clock += Time.deltaTime;
            timer.text = "Time: " + Math.Round(clock, 2);
        }
    }

    public void Play()
    {
        if(!play)
            for (int i = 0; i < collection.transform.childCount; i++)
            {
                collection.GetComponentsInChildren<objectScript>()[i].setPlay();
            }

        play = true;
    }
    public void Pause()
    {
        for (int i = 0; i < collection.transform.childCount; i++)
        {
            collection.GetComponentsInChildren<objectScript>()[i].setPause();
        }
        play = false;
    }
    public void ResetObjects()
    {
        for (int i = 0; i < collection.transform.childCount; i++)
        {
            collection.GetComponentsInChildren<objectScript>()[i].reset();
            play = false;
            timer.text = "Time: 0.00";
        }
    }
}
