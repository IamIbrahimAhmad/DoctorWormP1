using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text txtTime;
    public GameObject fire;
    public GameObject gameOver;

    public float remainingTime;

    public AudioSource theStart;
    public AudioSource half;
    public AudioSource fireT;
    public AudioSource last30;

    private void Start()
    {
        theStart.Play();
        fire.SetActive(false);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;
            print("Game Over");
            gameOver.SetActive(true);
            Time.timeScale = 0f;

        }
        int min = Mathf.FloorToInt(remainingTime / 60);
        int sec = Mathf.FloorToInt(remainingTime % 60);
        txtTime.text = string.Format("{0:00}:{1:00}", min, sec);

        if(remainingTime <= 150)
        {
            half.Play();
            print("Done");
        }

        if(remainingTime <= 60)
        {
            fire.SetActive(true);
            fireT.Play();
        }
        if(remainingTime <= 30)
        {
            last30.Play();
        }
        
    }
}
