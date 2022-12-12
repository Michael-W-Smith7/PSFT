using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    private increment myIncrement;
    [SerializeField] private bool isDelay;
    void Awake()
    {
        myIncrement = GameObject.Find("Scroll").GetComponentInChildren<increment>();
        if(isDelay)
            gameObject.GetComponent<TMP_InputField>().text = myIncrement.delay.ToString();
    }
    public void SetX()
    {
        myIncrement.SetX(int.Parse(gameObject.GetComponent<TMP_InputField>().text));
    }
    public void SetY()
    {
        myIncrement.SetY(int.Parse(gameObject.GetComponent<TMP_InputField>().text));
    }
    public void SetDelay()
    {
        myIncrement.SetDelay(float.Parse(gameObject.GetComponent<TMP_InputField>().text));
    }

}
