using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    public void IdleChangeColor()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, Random.Range(0, 0.5f));
    }
    public void RunChangeColor()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
    }
}
