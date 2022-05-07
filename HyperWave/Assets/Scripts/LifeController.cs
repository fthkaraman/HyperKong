using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public static int lifeValue = 3;
    Text score;
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "X " + lifeValue;
    }
}
