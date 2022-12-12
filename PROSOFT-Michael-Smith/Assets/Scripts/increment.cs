using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class increment: MonoBehaviour
{
    private TMP_Text myText;
    private TMP_Text timerText;
    private Transform scrollGameObject;

    private int currentNum = 1;
    private float timer;


    [SerializeField] public float delay = 1;
    [SerializeField] private int x;
    [SerializeField] private int y;

    private string finalText = "";


    void Start()
    {
        myText = gameObject.GetComponent<TMP_Text>();
        scrollGameObject = GameObject.Find("Scroll").transform;
        timerText = GameObject.Find("timer").GetComponentInChildren<TMP_Text>();
    }
    
    void Update()
    {
        if (timer >= delay)
        {
            bool fizzbuzz = false;
            if (Fizz())
            {
                finalText += "Fizz";
                fizzbuzz = true;
            }
            if (Buzz())
            {
                finalText += "Buzz";
                fizzbuzz = true;
            }
            if(!fizzbuzz)
                finalText += currentNum;

            finalText += "\n";

            myText.text += finalText;
            timer = 0;
            currentNum++;
            
            if(currentNum > 17)
            {
                scrollGameObject.position = new Vector3(scrollGameObject.position.x, scrollGameObject.position.y + (myText.preferredHeight / (currentNum - 1)), 0);
            }
        }
        else
            timer += Time.deltaTime;

        finalText = "";
        timerText.text = Math.Round((delay - timer), 2).ToString();
    }

    private bool Fizz()
    {
        // div by x
        if (x != 0 && currentNum % x == 0)
            return true;
        return false;

    }
    private bool Buzz()
    {
        // div by y
        if (y != 0 && currentNum % y == 0)
            return true;
        return false;
    }

    public void SetDelay(float Delay) { delay = Delay; timer = 0;}
    public void SetX(int X) { x = X; }
    public void SetY(int Y) { y = Y; }
}
