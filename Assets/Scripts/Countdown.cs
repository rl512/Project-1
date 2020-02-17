using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Countdown : MonoBehaviour
{

    float currentime = 0f;
    float startingtime= 120f;
    public Text CountDown; 

    // Start is called before the first frame update
    void Start()
    {
        currentime = startingtime; 
    }

    // Update is called once per frame
    void Update()
    {
        currentime -= 1 * Time.deltaTime;
        CountDown.text = currentime.ToString("0");

        if (currentime<=0) {

            currentime = 0;
            Time.timeScale = 0;
        }
    }
}
