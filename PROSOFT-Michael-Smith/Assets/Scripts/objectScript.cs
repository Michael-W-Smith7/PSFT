using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor;
using UnityEngine;

public class objectScript : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float directionAngle;
    [SerializeField] private float predictionTime;
    [SerializeField] private GameObject predictionSphere;
    
    private GameObject pSphere;

    private bool play = false;
    private bool pause = false;

    private GameObject textGameObject;
    private TMP_Text speedText;
    private TMP_Text directionText;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private bool isClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        textGameObject = GameObject.Find("CurrentObjectData");
        speedText = textGameObject.GetComponentsInChildren<TMP_Text>()[0];
        directionText = textGameObject.GetComponentsInChildren<TMP_Text>()[1];
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        pSphere = Instantiate(predictionSphere, initialPosition, initialRotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            speedText.text = "Speed: " + Math.Round(speed, 2);
            directionText.text = "Direction: " + Math.Round(transform.rotation.eulerAngles.y, 2);
        }
        transform.rotation = Quaternion.Euler(0, directionAngle, 0);
        pSphere.transform.position = initialPosition + (transform.rotation * Vector3.forward * speed * predictionTime);
    }
    
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                transform.parent.GetComponentsInChildren<objectScript>()[i].setNotClicked();
                isClicked = true;
            }
        }
    }

    IEnumerator MoveBall()
    {
        while(pause)
            yield return null;
        while(play)
        {
            transform.position += transform.rotation * Vector3.forward * speed * Time.deltaTime;
            yield return null;
        }

        yield return null;
    }

    public void setNotClicked() { isClicked = false; }
    public void setPause() { pause = true; play = false; }
    public void setPlay() { play = true; pause = false; StartCoroutine(MoveBall()); }

    public void reset()
    {
        play = false;
        pause = false;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
