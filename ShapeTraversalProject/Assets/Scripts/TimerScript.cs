using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public TMP_Text timerText;
    public float maxTime;
    private float time;  
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        time = maxTime;
        timerText.text = ((int)time).ToString();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        time = maxTime - (Time.time - startTime);
        timerText.text = ((int)time).ToString();

        if (time < 0 )
            SceneManager.LoadScene("MainMenu");
    }
}
